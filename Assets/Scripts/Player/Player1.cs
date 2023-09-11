using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1: MonoBehaviour
{
    public Vector2 laneOne;
    public Vector2 laneTwo;
    private Vector2 targetPos;
    private GameManager gameManager;
    private PlayerHealth playerHealth;
    private Tutorial tutorial;
    private bool isOnOne = false;

    private void Start()
    {
        targetPos = transform.position; // Initialize the target position to the current position
        gameManager = FindObjectOfType<GameManager>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        tutorial = FindObjectOfType<Tutorial>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (tutorial != null)
            {
                if (touch.position.x < Screen.width / 2 && touch.phase == TouchPhase.Began  && !tutorial.isGameOver)
                {
                    // Determine the target lane based on the current position
                    if (isOnOne)
                        targetPos = laneTwo;
                    else
                        targetPos = laneOne;

                    isOnOne = !isOnOne;
                    transform.position = targetPos;
                }
            }
            else
            {
                if (touch.position.x < Screen.width / 2 && touch.phase == TouchPhase.Began  && !gameManager.isGameOver)
                {
                    // Determine the target lane based on the current position
                    if (isOnOne)
                        targetPos = laneTwo;
                    else
                        targetPos = laneOne;

                    isOnOne = !isOnOne;
                    transform.position = targetPos;
                }
            }
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "CirclePlayer")
        {
            if (collision.gameObject.tag == "SquareEnemy")
            {
                playerHealth.lives -= 1;
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "CircleEnemy")
            {
                gameManager.score += 1;
                Destroy(collision.gameObject);
            }
        }
    }
}

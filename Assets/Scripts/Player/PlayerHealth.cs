using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private GameManager gameManager;
    public int lives = 3;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lives < 3)
        {
            gameManager.livesList[lives].gameObject.SetActive(false);
            if (lives == 0)
            {
                gameManager.GameOver();
            }
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI leftText;
    public TextMeshProUGUI rightText;
    public TextMeshProUGUI ruleHeader;
    public TextMeshProUGUI ruleText;

    public bool isLeftTouched = false;
    public bool isRightTouched = false;
    public bool isGameOver = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x < Screen.width / 2 && touch.phase == TouchPhase.Began && !isGameOver)
            {
                leftText.gameObject.SetActive(false);
                isLeftTouched = true;
            }
            if (touch.position.x > Screen.width / 2 && touch.phase == TouchPhase.Began && !isGameOver)
            {
                rightText.gameObject.SetActive(false);
                isRightTouched = true;
            }
        }
        if(isRightTouched && isLeftTouched)
        {
            ruleHeader.gameObject.SetActive(true);
            ruleText.gameObject.SetActive(true);
            StartCoroutine(StartGameAfterTutorial());
        }
    }

    IEnumerator StartGameAfterTutorial()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
}

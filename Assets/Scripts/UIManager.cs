using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Text scoretext;
    [SerializeField]
    private Image LivesImg;
    [SerializeField]
    private Sprite[] liveSprites;
    [SerializeField]
    private Text GameOverText;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        scoretext.text = "Score: " + 0;
        GameOverText.gameObject.SetActive(false);
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int playerScore)
    {
        scoretext.text = "Score: " + playerScore;
    }

    public void UpdateLives(int currentLives)
    {
        LivesImg.sprite = liveSprites[currentLives];

        if (currentLives <= 0)
        {
           GameOverSequence();
        }
    }

    void GameOverSequence()
    {
        GameOverText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlicker());
        gameManager.GameOver();
    }

IEnumerator GameOverFlicker()
{
    while (true)
    {
        GameOverText.text = "Game Over";
        yield return new WaitForSeconds(0.5f);
        GameOverText.text = "";
        yield return new WaitForSeconds(0.5f);
    }

}


}

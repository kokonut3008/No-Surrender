using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScore : MonoBehaviour
{
    public Text scoreText;
    public Text timerText;
    public Transform playerTransform;
    public float countdownTime = 30f; // Time in seconds
    public Canvas endGameCanvas;
    public Canvas scoreCanvas;
    public Text endGameScore;
    private float score;
    private int intScore;
    private float timer;
    private bool gameEnded = false;

    void Start()
    {
        score = 0f;
        timer = countdownTime;
        endGameCanvas.gameObject.SetActive(false);
        scoreCanvas.gameObject.SetActive(true);
    }

    void Update()
    {
        if (!gameEnded)
        {
            // Update the score based on the player's scale
            score = playerTransform.localScale.x * 1000 - 1000;

            intScore = (int)score;
            if (score - intScore != 0)
            {
                intScore++;
            }

            // Update the score text
            scoreText.text = "SCORE: " + intScore.ToString();

            // Update the countdown timer
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                timer = 0f;
                gameEnded = true;
                EndGame();
            }

            // Update the timer text
            timerText.text = "TIME: " + Mathf.Ceil(timer).ToString();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();
            }
        }
    }

    public void EndGame()
    {
        scoreCanvas.gameObject.SetActive(false);
        endGameCanvas.gameObject.SetActive(true);
        endGameScore.text = intScore.ToString();
    }

    void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

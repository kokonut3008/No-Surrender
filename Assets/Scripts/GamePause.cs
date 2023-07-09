using UnityEngine;
using UnityEngine.UI;

public class GamePause : MonoBehaviour
{
    public Canvas pauseCanvas;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Freeze time

        // Activate the pause canvas and display the text
        pauseCanvas.gameObject.SetActive(true);
    }

    void ContinueGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Restore time scale to normal

        // Deactivate the pause canvas
        pauseCanvas.gameObject.SetActive(false);
    }
}

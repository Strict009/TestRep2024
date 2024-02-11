using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
     
        pauseMenuUI.SetActive(false);

        
        Time.timeScale = 1f;

        
        isPaused = false;
    }

    void PauseGame()
    {
        
        pauseMenuUI.SetActive(true);

        
        Time.timeScale = 0f;

        
        isPaused = true;
    }
}

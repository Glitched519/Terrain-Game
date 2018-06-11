using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Transform player;
    Vector3 origin = new Vector3(954.1f, 124.1f, 919f);  
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void LoadMenu()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        SceneManager.LoadScene("Scenes/Menu");
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void ResetPosition()
    {
        player.position = origin;
    }

    public void QuitGame()
    {
        print("Quitting Game...");
        Application.Quit();  
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{
    public CraftMenu craftMenu;
    public GameObject pauseMenuUI;

    private static bool gameIsPaused;

    public void LoadScene(int SceneNum)
    {
        SceneManager.LoadScene(SceneNum);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

                if (craftMenu.FlagOpenCraftMenu)
                {
                    craftMenu.CloseCraftMenu();
                }
                else
                {
                    if (gameIsPaused)
                        Resume();
                    else
                        Pause();
                }
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}

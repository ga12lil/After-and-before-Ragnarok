using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{
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
                LoadScene(0);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathScreenController : MonoBehaviour
{
    [SerializeField] private TMP_Text deathMessage;

    void Start()
    {
        string message = "You died!";
        deathMessage.text = message;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scoreBoard : MonoBehaviour
{
    public void retry()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

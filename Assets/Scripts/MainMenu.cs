using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Called when the Play button is tapped
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}

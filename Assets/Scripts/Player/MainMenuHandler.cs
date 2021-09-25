using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private Canvas _mainMenuCanvas;

    public void StartGame()
    {
        FindObjectOfType<SceneLoader>().StartGame();
    }

    public void QuitGame()
    {
        FindObjectOfType<SceneLoader>().QuitGame();
    }
}

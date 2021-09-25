using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    public void PlayAgain()
    {
        FindObjectOfType<SceneLoader>().PlayAgain();
    }

    public void QuitGame()
    {
        FindObjectOfType<SceneLoader>().QuitLevel();
    }
}

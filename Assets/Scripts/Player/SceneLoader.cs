using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // public Animator _transition;

    public void StartGame()
    {
        int sceneIndex = 1;
        this.StartCoroutine(this.LoadScene(sceneIndex));
    }

    public void PlayAgain()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        this.StartCoroutine(this.LoadScene(sceneIndex));
        Time.timeScale = 1f;
    }

    public void QuitLevel()
    {
        int sceneIndex = 0;
        this.StartCoroutine(this.LoadScene(sceneIndex));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator LoadScene(int sceneIndex)
    {
        // this._transition.SetTrigger("Start");

        yield return new WaitForSeconds(0); // 1f

        SceneManager.LoadScene(sceneIndex);
    }
}

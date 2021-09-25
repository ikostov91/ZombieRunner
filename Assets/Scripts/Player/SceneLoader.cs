using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Awake()
    {
        this.SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int sceneLoaders = FindObjectsOfType<SceneLoader>().Length;
        if (sceneLoaders > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void StartGame()
    {
        int sceneIndex = 1;
        this.LoadScene(sceneIndex);
    }

    public void PlayAgain()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        this.LoadScene(sceneIndex);
        Time.timeScale = 1f;
    }

    public void QuitLevel()
    {
        int sceneIndex = 0;
        this.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

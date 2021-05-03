using Assets.Scripts.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _menuTheme;
    [SerializeField] private AudioClip[] _gameplayThemes;
    
    private AudioSource _audioSource;

    private void Start()
    {
        this._audioSource = GetComponent<AudioSource>();
        this.PlayTheme();
    }

    private void PlayTheme()
    {
        this._audioSource.loop = true;
        if (SceneManager.GetActiveScene().name == LevelConstants.MainMenu)
        {
            this._audioSource.clip = this._menuTheme;
            this._audioSource.Play();
        }
        else
        {
            int randomIndex = Random.Range(0, this._gameplayThemes.Length);
            this._audioSource.clip = this._gameplayThemes[randomIndex];
            this._audioSource.Play();
        }
    }
}

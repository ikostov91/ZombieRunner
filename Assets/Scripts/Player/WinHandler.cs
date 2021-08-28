using UnityEngine;

namespace Assets.Scripts.Player
{
    public class WinHandler : MonoBehaviour
    {
        [SerializeField] private Canvas _winCanvas;

        private void Start()
        {
            this._winCanvas.enabled = false;
        }

        public void HandleWin()
        {
            this._winCanvas.enabled = true;
            FindObjectOfType<PauseHandler>().OnGameWon();
        }
    }
}

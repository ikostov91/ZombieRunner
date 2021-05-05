using Assets.Scripts.Interfaces;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public class PlayerHealth : MonoBehaviour, IDamagable
    {
        [SerializeField] private float _hitPoints = 100f;
        [SerializeField] private TextMeshProUGUI _healthText;

        void Update()
        {
            this.DisplayHealth();
        }

        public void TakeDamage(float damage)
        {
            this._hitPoints -= damage;
            if (this._hitPoints <= 0)
            {
                this.GetComponent<DeathHandler>().HandleDeath();
            }
        }

        private void DisplayHealth()
        {
            this._healthText.text = Mathf.Max(this._hitPoints, 0f).ToString();
        }
    }
}


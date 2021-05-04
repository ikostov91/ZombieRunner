using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public class PlayerHealth : MonoBehaviour, IDamagable
    {
        [SerializeField] private float _hitPoints = 100f;

        public void TakeDamage(float damage)
        {
            this._hitPoints -= damage;
            if (this._hitPoints <= 0)
            {
                this.GetComponent<DeathHandler>().HandleDeath();
            }
        }
    }
}


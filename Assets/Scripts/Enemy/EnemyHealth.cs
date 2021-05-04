using Assets.Scripts.Constants;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.EnemyScripts
{
    public class EnemyHealth : MonoBehaviour, IDamagable
    {
        [SerializeField] private AudioClip _deathSound;
        [SerializeField] private AudioClip[] _damageTakenSounds;
        [SerializeField] private float _soundsVolume = 1.5f;

        [SerializeField] private float _hitPoints = 100f;

        private bool _isDead = false;

        public bool IsDead => this._isDead;

        public void TakeDamage(float damage)
        {
            this._hitPoints -= damage;
            if (this._hitPoints <= 0f)
            {
                this.Die();
            }
            else
            {
                BroadcastMessage(MessageConstants.OnDamageTaken);
            }
        }

        private void Die()
        {
            if (this._isDead)
            {
                return;
            }

            this._isDead = true;
            GetComponent<Animator>().SetTrigger(AnimationConstants.Die);
            AudioSource.PlayClipAtPoint(this._deathSound, this.transform.position, this._soundsVolume);
        }
    }
}

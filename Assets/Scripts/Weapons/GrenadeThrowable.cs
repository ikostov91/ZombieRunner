using Assets.Scripts.EnemyScripts;
using Assets.Scripts.Interfaces;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GrenadeThrowable : MonoBehaviour
{
    [SerializeField] private float _explodeDelay = 5f;
    [SerializeField] private float _soundVolume = 1f;
    [SerializeField] private float _damagePoints = 100f;
    [SerializeField] private float _explosionForce = 700f;
    [SerializeField] private float _explosionRadius = 15f;
    [SerializeField] private float _noiseAttractDistance = 50f;
    [SerializeField] private float _explosionDuration = 3f;
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private AudioClip _explosionSound;

    void Start()
    {
        Invoke(nameof(this.Explode), this._explodeDelay);
    }

    private void Explode()
    {
        this.PlayExplosionVFX();
        AudioSource.PlayClipAtPoint(this._explosionSound, this.gameObject.transform.position, this._soundVolume);
        this.DealDamage();
        this.AttractNearbyEnemies();
        Destroy(this.gameObject);
    }

    private void PlayExplosionVFX()
    {
        ParticleSystem explosion = Instantiate(
            this._explosionEffect,
            this.gameObject.transform.position,
            this.gameObject.transform.rotation);
        explosion.Play();
        Destroy(explosion, this._explosionDuration);
    }

    private void DealDamage()
    {
        Collider[] colliders = Physics.OverlapSphere(this.gameObject.transform.position, this._explosionRadius);
        foreach (var collider in colliders)
        {
            if (collider.gameObject.TryGetComponent(out IDamagable damagableObject))
            {
                float proximity = (collider.gameObject.transform.position - this.gameObject.transform.position).magnitude;
                float damageMultiplier = 1 - (proximity / this._explosionRadius);
                damagableObject.TakeDamage(this._damagePoints * damageMultiplier);

                var rb = collider.gameObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(this._explosionForce, this.gameObject.transform.position, this._explosionRadius);
                }
            }
        }
    }

    private void AttractNearbyEnemies()
    {
        EnemyAI[] enemies = FindObjectsOfType<EnemyAI>();
        foreach (EnemyAI enemy in enemies)
        {
            float distanceBetween = Vector3.Distance(this.gameObject.transform.position, enemy.gameObject.transform.position);
            if (distanceBetween <= this._noiseAttractDistance)
            {
                enemy.InvestigateEvent(this.gameObject.transform.position);
            }
        }
    }
}

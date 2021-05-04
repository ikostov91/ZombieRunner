using Assets.Scripts.EnemyScripts;
using Assets.Scripts.Interfaces;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GrenadeThrowable : MonoBehaviour
{
    [SerializeField] private float _explodeDelay = 5f;
    [SerializeField] private float _soundVolume = 1f;
    [SerializeField] private float _damagePoints = 300f;
    [SerializeField] private float _explosionRadius = 15f;
    [SerializeField] private float _noiseAttractDistance = 50f;
    [SerializeField] private AudioClip _explosionSound;

    void Start()
    {
        this.StartCoroutine(this.Explode());
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(this._explodeDelay);
        AudioSource.PlayClipAtPoint(this._explosionSound, this.gameObject.transform.position, this._soundVolume);
        this.DealDamage();
        this.AttractNearbyEnemies();
        Destroy(this.gameObject);
    }

    private void DealDamage()
    {
        Collider[] colliders = Physics.OverlapSphere(this.gameObject.transform.position, this._explosionRadius);
        foreach (var collider in colliders)
        {
            if (collider.gameObject.TryGetComponent(out IDamagable damagableObject))
            {
                damagableObject.TakeDamage(this._damagePoints);
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

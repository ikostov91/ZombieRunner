using System.Collections;
using UnityEngine;

public class GrenadeThrowable : MonoBehaviour
{
    [SerializeField] private float _explodeDelay = 5f;

    void Start()
    {
        this.StartCoroutine(this.Explode());
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(this._explodeDelay);
        Destroy(this.gameObject);
    }
}

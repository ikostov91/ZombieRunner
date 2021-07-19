using Assets.Scripts.Pickups;
using System.Collections;
using System.Linq;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private PickupsDataScriptableObject pickupsData;
    [SerializeField] private float _newSpawnDelay = 4f;

    void Start()
    {
        this.SpawnInitialPickups();
    }

    private void SpawnInitialPickups()
    {
        PickupBase[] pickups = this.pickupsData.pickupPrefabs;
        Vector3[] spawnPoints = this.pickupsData.pickupSpawnPoints;
        foreach (Vector3 point in spawnPoints)
        {
            int pickupIndex = Random.Range(0, pickups.Length);
            var currentPickup = pickups[pickupIndex];
            Instantiate(currentPickup, point, Quaternion.identity);
        }
    }

    public void SpawnNewPickup()
    {
        foreach (Vector3 point in this.pickupsData.pickupSpawnPoints)
        {
            var nearbyColliders = Physics.OverlapSphere(point, 3f);
            if (!nearbyColliders.Any(x => x.gameObject.TryGetComponent(out PickupBase pickup)))
            {
                this.StartCoroutine(this.SpawnPickUpAtPoint(point));
            }
        }
    }

    private IEnumerator SpawnPickUpAtPoint(Vector3 point)
    {
        yield return new WaitForSeconds(this._newSpawnDelay);

        PickupBase[] pickups = this.pickupsData.pickupPrefabs;
        int pickupIndex = Random.Range(0, pickups.Length);
        var currentPickup = pickups[pickupIndex];
        Instantiate(currentPickup, point, Quaternion.identity);
    }
}

using Assets.Scripts.Pickups;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private PickupBase[] _pickupPrefabs;
    [SerializeField] private Vector3[] _spawnPoints;

    void Start()
    {
        this.SpawnInitialPickups();
    }

    private void SpawnInitialPickups()
    {
        foreach (Vector3 position in this._spawnPoints)
        {
            int pickupIndex = Random.Range(0, this._pickupPrefabs.Length);
            var pickupPrefab = this._pickupPrefabs[pickupIndex];
            Instantiate(pickupPrefab, position, Quaternion.identity);
        }
    }
}

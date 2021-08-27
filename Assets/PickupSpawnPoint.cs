using Assets.Scripts.Pickups;
using System.Collections;
using UnityEngine;

public class PickupSpawnPoint : MonoBehaviour
{
    [SerializeField] private PickupsDataScriptableObject pickupsData;
    [SerializeField] private float _newSpawnDelay = 5f;
    private bool _isSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        this.SpawnPickUp();
        
    }

    // Update is called once per frame
    void Update()
    {
        var isPickedUp = this.transform.childCount == 0;
        if (isPickedUp && !this._isSpawning)
        {
            this._isSpawning = true;
            this.StartCoroutine(this.SpawnPickUpCoroutine());
        }
    }

    private IEnumerator SpawnPickUpCoroutine()
    {
        yield return new WaitForSeconds(this._newSpawnDelay);
        this.SpawnPickUp();
    }

    private void SpawnPickUp()
    {
        PickupBase[] pickups = this.pickupsData.pickupPrefabs;
        int pickupIndex = Random.Range(0, pickups.Length);
        var currentPickup = pickups[pickupIndex];
        Instantiate(currentPickup, this.transform.position, Quaternion.identity, this.transform);
        this._isSpawning = false;
    }
}

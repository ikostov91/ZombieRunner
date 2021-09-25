using Assets.Scripts.Constants;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    void Start()
    {
        var spawnPoints = GameObject.FindGameObjectsWithTag(TagConstants.PlayerSpawnPoint);
        var randomIndex = Random.Range(0, spawnPoints.Length);
        var selectedSpawnPoint = spawnPoints[randomIndex];
        this.gameObject.transform.position = selectedSpawnPoint.transform.position;
        this.gameObject.transform.rotation = selectedSpawnPoint.transform.rotation;
    }
}

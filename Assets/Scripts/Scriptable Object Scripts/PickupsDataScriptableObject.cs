using Assets.Scripts.Pickups;
using UnityEngine;

[CreateAssetMenu(fileName = "PickupsData", menuName = "ScriptableObjects/PickupsDataScriptableObject", order = 1)]
public class PickupsDataScriptableObject : ScriptableObject
{
    [SerializeField] public PickupBase[] pickupPrefabs;
    [SerializeField] public Vector3[] pickupSpawnPoints;
}

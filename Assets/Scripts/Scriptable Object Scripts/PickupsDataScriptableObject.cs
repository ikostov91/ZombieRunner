using Assets.Scripts.Pickups;
using UnityEngine;

[CreateAssetMenu(fileName = "PickupsData", menuName = "ScriptableObjects/PickupsDataScriptableObject", order = 1)]
public class PickupsDataScriptableObject : ScriptableObject
{
    public PickupBase[] pickupPrefabs;
}

using System;
using UnityEngine;

namespace Assets.Scripts.Pickups
{
    public class HealthPickup : PickupBase
    {
        [SerializeField] private float _healthPoints = 50f;

        public override void OnTriggerEnter(Collider otherCollider)
        {
            Debug.Log("GET HEALTH");
        }
    }
}

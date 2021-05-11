using UnityEngine;

namespace Assets.Scripts.Pickups
{
    public abstract class PickupBase : MonoBehaviour
    {
        public abstract void OnTriggerEnter(Collider otherCollider);
    }
}

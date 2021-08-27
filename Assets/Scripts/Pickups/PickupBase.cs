using UnityEngine;

namespace Assets.Scripts.Pickups
{
    public abstract class PickupBase : MonoBehaviour
    {
        private void Start() { }

        void OnDestroy() { }

        public abstract void OnTriggerEnter(Collider otherCollider);
    }
}

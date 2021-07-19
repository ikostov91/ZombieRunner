using UnityEngine;

namespace Assets.Scripts.Pickups
{
    public abstract class PickupBase : MonoBehaviour
    {
        [SerializeField] protected PickupSpawner pickupSpawner;

        private void Start()
        {
            this.pickupSpawner = FindObjectOfType<PickupSpawner>();
        
        }

        void OnDestroy()
        {
            if (this.pickupSpawner != null)
            {
                this.pickupSpawner.SpawnNewPickup();
            }
        }

        public abstract void OnTriggerEnter(Collider otherCollider);
    }
}

using Assets.Scripts.Constants;
using Assets.Scripts.PlayerScripts;
using UnityEngine;

namespace Assets.Scripts.Pickups
{
    public class HealthPickup : PickupBase
    {
        [SerializeField] private AudioClip _pickUpSound;

        public override void OnTriggerEnter(Collider otherCollider)
        {
            if (otherCollider.gameObject.CompareTag(TagConstants.Player))
            {
                var health = otherCollider.gameObject.GetComponent<PlayerHealth>();
                health.RestoreHealth();
                AudioSource.PlayClipAtPoint(this._pickUpSound, this.transform.position);
                Destroy(this.gameObject);
            }
        }
    }
}

using UnityEngine;
using Assets.Scripts.AmmoScripts;
using Assets.Scripts.Constants;
using Assets.Scripts.Pickups;

namespace Assets.Scripts.PickupScriprs
{
    public class AmmoPickUp : PickupBase
    {
        [SerializeField] private int _ammoAmmount = 5;
        [SerializeField] private AmmoType _ammoType = AmmoType.PistolBullets;
        [SerializeField] private AudioClip _pickUpSound;

        public override void OnTriggerEnter(Collider otherCollider)
        {
            if (otherCollider.gameObject.CompareTag(TagConstants.Player))
            {
                var ammo = FindObjectOfType<Ammo>();
                ammo.IncreaseCurrentAmmo(this._ammoType, this._ammoAmmount);
                AudioSource.PlayClipAtPoint(this._pickUpSound, this.transform.position);
                Destroy(this.gameObject);
            }
        }
    }
}

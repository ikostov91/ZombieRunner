using Assets.Scripts.Constants;
using Assets.Scripts.Pickups;
using UnityEngine;

public class ArmorPickup : PickupBase
{
    [SerializeField] private AudioClip _pickUpSound;

    public override void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag(TagConstants.Player))
        {
            var armor = otherCollider.gameObject.GetComponent<PlayerArmor>();
            armor.RestoreArmor();
            AudioSource.PlayClipAtPoint(this._pickUpSound, this.transform.position);
            Destroy(this.gameObject);
        }
    }
}

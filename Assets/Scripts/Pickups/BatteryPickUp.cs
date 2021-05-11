using Assets.Scripts.Constants;
using UnityEngine;
using Assets.Scripts.PlayerScripts;
using Assets.Scripts.Pickups;

namespace Assets.Scripts.PickupScriprs
{
    public class BatteryPickUp : PickupBase
    {
        [SerializeField] private float _restoreAngle = 90f;
        [SerializeField] private float _addIntensity = 1f;

        public override void OnTriggerEnter(Collider otherCollider)
        {
            if (otherCollider.gameObject.tag == TagConstants.Player)
            {
                var flashlight = otherCollider.GetComponentInChildren<FlashLightSystem>();
                flashlight.RestoreLightAngle(this._restoreAngle);
                flashlight.AddLightIntenisty(this._addIntensity);
                Destroy(this.gameObject);
            }
        }
    }
}

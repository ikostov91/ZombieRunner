using Assets.Scripts.AmmoScripts;
using TMPro;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected AmmoType _ammoType;
    [SerializeField] protected Ammo _ammoSlot;
    [SerializeField] protected Camera _fpsCamera;
    [SerializeField] private TextMeshProUGUI _ammoText;

    protected void DisplayAmmo()
    {
        this._ammoText.text = this._ammoSlot.GetCurrentAmmo(this._ammoType).ToString();
    }
}

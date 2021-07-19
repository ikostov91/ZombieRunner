using Assets.Scripts.PlayerScripts;
using TMPro;
using UnityEngine;

public class PlayerArmor : MonoBehaviour
{
    private const float MAX_HITPOINTS = 100f;

    [SerializeField] private float _hitPoints = MAX_HITPOINTS;
    [SerializeField] private TextMeshProUGUI _armorText;

    private PlayerHealth _playerHealth;

    void Start()
    {
        this._playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        this.DisplayArmor();
    }

    public void DisplayArmor()
    {
        this._armorText.text = Mathf.Max(this._hitPoints, 0f).ToString();
    }

    public void RestoreArmor()
    {
        this._hitPoints = MAX_HITPOINTS;
    }

    public float TakeDamage(float damage)
    {
        this._hitPoints -= damage;
        if (this._hitPoints < 0f)
        {
            var remainingHitPoints = Mathf.Abs(this._hitPoints);
            this._hitPoints = 0f;
            return remainingHitPoints;
        }
        else
        {
            return 0f;
        }
    }
}

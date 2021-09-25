using Assets.Scripts.EnemyScripts;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;
    private EnemyHealth _enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        this._enemyHealth = this.gameObject.GetComponentInParent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        var currentHealth = this._enemyHealth.CurrentHealth;
        if (currentHealth <= 0f)
        {
            Destroy(this.gameObject);
        }

        this._slider.normalizedValue = Mathf.InverseLerp(0, this._enemyHealth.MaxHealth, currentHealth);
        this._fill.color = this._gradient.Evaluate(this._slider.normalizedValue);
    }
}

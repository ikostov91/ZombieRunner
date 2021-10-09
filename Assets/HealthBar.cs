using Assets.Scripts.EnemyScripts;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Slider _slider;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;
    private EnemyHealth _enemyHealth;

    private Coroutine _makeVisibleCoroutine;

    [SerializeField] private float _visibilityDelay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        this._canvas = this.gameObject.GetComponent<Canvas>();
        this._canvas.enabled = false;
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

    public void OnDamageTaken()
    {
        this.StartCoroutine(this.MakeVisible());
        if (this._makeVisibleCoroutine != null)
            this.StopCoroutine(this._makeVisibleCoroutine);

        this._makeVisibleCoroutine = this.StartCoroutine(this.MakeVisible());
    }

    private IEnumerator MakeVisible()
    {
        this._canvas.enabled = true;
        yield return new WaitForSeconds(this._visibilityDelay);
        this._canvas.enabled = false;
    }
}

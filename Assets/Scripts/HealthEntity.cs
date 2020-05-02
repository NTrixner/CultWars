using UnityEngine;
using UnityEngine.UI;

public abstract class HealthEntity : MonoBehaviour
{
    [SerializeField]
    private float Health = 100f;

    [SerializeField]
    private float MaxHealth = 100f;

    [SerializeField]
    public Collider2D bodyCollider;

    [SerializeField] private Image healthbar;

    [SerializeField] private Color healthyColor;

    [SerializeField] private Color deadColor;

    [SerializeField] private RectTransform healthbarTransform;
    private float healthbarOriginalWidth;

    void Awake()
    {
        // workaround because assigning as parameter does not work
        //Transform healthbarImage = gameObject.transform.Find ("Healthbar").GetComponent<Image> ();
        healthbar.color = healthyColor;
        //healthbarTransform = transform.Find ("Healthbar").GetComponent<RectTransform> ();
        healthbarOriginalWidth = 1f;
    }

    protected void UpdateHealthEntity()
    {
        //Debug.Log("Update healthentity");
        if (healthbar != null)
        {
            UpdateHealthbar();
        }
    }

    private void UpdateHealthbar()
    {
        float value = (Health / MaxHealth);
        Color newColor = Color.Lerp(deadColor, healthyColor, value);

        healthbar.color = newColor;

        float oldWidth = healthbarTransform.rect.width;
        float newWidth = healthbarOriginalWidth * value;

        float y = healthbarTransform.sizeDelta.y;
        healthbarTransform.sizeDelta = new Vector2(newWidth, y);

    }

    public void ReduceHealth(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    public void Heal(float regain)
    {
        Health += regain;
        if (Health >= MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    public bool HasCollision(Collider2D collision)
    {
        return bodyCollider == collision;
    }

    public abstract void Die();
}

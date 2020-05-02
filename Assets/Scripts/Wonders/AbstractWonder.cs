using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractWonder : MonoBehaviour
{
    
    [SerializeField]
    public Button button;

    [SerializeField]
    private float favorCost;

    [SerializeField]
    private float favorGain;

    [SerializeField]
    public Cooldown cooldown;

    [SerializeField]
    Cooldown wonderDuration;
    [SerializeField]
    Cooldown wonderEffectDuration;

    [SerializeField]
    protected bool effectStartsAfterWonder;

    protected bool isActive;

    protected bool isEffectActive;

    private FavorCount favorCount;

    public virtual void Update() {
        UpdateWonder();
    }

    public void OnEnable() {
        button.onClick.AddListener(() => {
        if (!cooldown.IsRunning())
        {
            button.enabled = false;
            cooldown.ResetCooldown();
            cooldown.OnCooldownEnds += () => button.enabled = true;
            OnWonderButtonClicked();
        }
        });
        favorCount = GameObject.Find("Priest").GetComponent<FavorCount>();
    }

    public void UpdateWonder()
    {
        if (favorCost > favorCount.GetFavor()) {
            button.enabled = false;
        } else if (!button.enabled) {
            button.enabled = !cooldown.IsRunning();
        }

        if (isActive && !wonderDuration.IsRunning())
        {
            EndWonder();
            if (effectStartsAfterWonder)
            {
                StartWonderEffect();
            }
        }
        if (isEffectActive && !wonderEffectDuration.IsRunning())
        {
            EndWonderEffect();
        }
    }

    public virtual void OnWonderButtonClicked() {
        Debug.Log("abstract wonder button clicked");
        StartWonder();
    }

    public void StartWonder()
    {
        wonderDuration.ResetCooldown();
        favorCount.DecreaseFavor(favorCost);
        OnStartWonder();
        if (!effectStartsAfterWonder)
        {
            OnStartWonderEffect();
        }
        isActive = true;
    }

    protected abstract void OnStartWonder();
    protected abstract void OnEndWonder();

    protected virtual void OnStartWonderEffect() {}
    protected virtual void OnEndWonderEffect() {}

    private void EndWonder()
    {
        isActive = false;
        favorCount.IncreaseFavor(favorGain);
    }


    private void StartWonderEffect()
    {
        isEffectActive = true;
        wonderEffectDuration.ResetCooldown();
        OnStartWonderEffect();
    }

    private void EndWonderEffect()
    {
        isEffectActive = false;
        OnEndWonderEffect();
    }

}
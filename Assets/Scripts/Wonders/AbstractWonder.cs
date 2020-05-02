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
        Debug.Log("abstract wonder update");
        UpdateWonder();
    }

    public void OnEnable() {
        button.onClick.AddListener(ButtonListener);
    }

    public void ButtonListener()
    {
        if (!cooldown.IsRunning())
        {
            button.interactable = false;
            cooldown.ResetCooldown();
            cooldown.OnCooldownEnds += () => button.interactable = true;
            OnWonderButtonClicked();
        }
    }

    public void UpdateWonder()
    {
        GameObject priest = GameObject.Find("Priest");
        if(priest != null)
        {
            if (favorCount == null)
            {
                favorCount = priest.GetComponent<FavorCount>();
                if (favorCount == null)
                {
                    return;
                }
            }
            if (cooldown == null)
            {
                cooldown = priest.GetComponent<Cooldown>();
                if (cooldown == null)
                {
                    return;
                }
            }
        }
        else
        {
            return;
        }
        if (favorCost > favorCount.GetFavor()) {
            button.interactable = false;
        } else {
            button.interactable = !cooldown.IsRunning();
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
        Debug.Log("start wonder");
        wonderDuration.ResetCooldown();
        favorCount.DecreaseFavor(favorCost);
        OnStartWonder();
        if (!effectStartsAfterWonder)
        {
            StartWonderEffect();
        }
        isActive = true;
    }

    protected abstract void OnStartWonder();
    protected abstract void OnEndWonder();

    protected virtual void OnStartWonderEffect() {}
    protected virtual void OnEndWonderEffect() {}

    private void EndWonder()
    {
        Debug.Log("end wonder");
        isActive = false;
        favorCount.IncreaseFavor(favorGain);
    }


    private void StartWonderEffect()
    {
        Debug.Log("start wonder effect");
        isEffectActive = true;
        wonderEffectDuration.ResetCooldown();
        OnStartWonderEffect();
    }

    private void EndWonderEffect()
    {
        Debug.Log("end wonder effect");
        isEffectActive = false;
        OnEndWonderEffect();
    }

}
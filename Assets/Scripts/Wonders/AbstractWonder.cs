using UnityEngine;

public abstract class AbstractWonder : MonoBehaviour
{

    [SerializeField]
    Cooldown cooldown;
    [SerializeField]
    Cooldown effectCooldown;

    [SerializeField]
    protected bool effectStartsAfterWonder;

    protected bool isActive;

    protected bool isEffectActive;


    public void UpdateWonder()
    {
        if (isActive && !cooldown.IsRunning())
        {
            EndWonder();
            if (effectStartsAfterWonder)
            {
                StartWonderEffect();
            }
        }
        if (isEffectActive && !effectCooldown.IsRunning())
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
        OnStartWonder();
        if (!effectStartsAfterWonder)
        {
            OnStartWonderEffect();
        }
    }

    protected abstract void OnStartWonder();
    protected abstract void OnEndWonder();

    protected abstract void OnStartWonderEffect();
    protected abstract void OnEndWonderEffect();

    private void EndWonder()
    {
        isActive = false;
    }


    private void StartWonderEffect()
    {
        isEffectActive = true;
        effectCooldown.ResetCooldown();
        OnStartWonderEffect();
    }

    private void EndWonderEffect()
    {
        isEffectActive = false;
        OnEndWonderEffect();
    }

}
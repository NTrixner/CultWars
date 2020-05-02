
using UnityEngine;
using TMPro;

public class FavorCount : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _text;
    private float favor;

    public float GetFavor() {
        return favor;
    }

    void Update() {
        _text.text = favor.ToString();
    }

    public void IncreaseFavor(float value) {
        favor += value;
    }

    public void DecreaseFavor(float value) {
        favor -= value;
    }
}

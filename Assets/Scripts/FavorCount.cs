
using UnityEngine;
using TMPro;

public class FavorCount : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _text;
    private int favor;

    void Update() {
        _text.text = favor.ToString();
    }

    void IncreaseFavor(int value) {
        favor -= value;
    }

    void DecreaseFavor(int value) {
        favor += value;
    }
}

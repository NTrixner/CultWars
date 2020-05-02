using UnityEngine;
using TMPro;

public class FollowerCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private int followers = 42;

    void Update() {
        followers = FindObjectsOfType<GoodGuyAI>().Length;
        _text.text = followers.ToString();
    }

}

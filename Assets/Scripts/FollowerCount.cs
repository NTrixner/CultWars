using UnityEngine;
using TMPro;

public class FollowerCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private int followers = 42;

    void Update() {
        // todo: add here the logic to update follower count
        _text.text = followers.ToString();
    }

}

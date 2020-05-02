using UnityEngine;
using TMPro;

public class FollowerCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private int followers = 42;


    private void Awake()
    {
        _text = GameObject.Find("Follower Display").GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update() {
        followers = FindObjectsOfType<GoodGuyAI>().Length;
        _text.text = followers.ToString();
    }

}

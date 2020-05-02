using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialPanel : MonoBehaviour
{
    [SerializeField] private string title;

    [SerializeField] private string content;

    [SerializeField] private GameObject nextGameObjectShown;

    [SerializeField] private TextMeshProUGUI titleMesh;
    [SerializeField] private TextMeshProUGUI contentMesh;

    [SerializeField] private Button button;

    void OnEnable()
    {
        titleMesh.text = title;
        contentMesh.text = content;
        if (nextGameObjectShown != null) {
            button.onClick.AddListener(() => nextGameObjectShown.SetActive(true));
        }
        button.onClick.AddListener(()=> gameObject.SetActive(false));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

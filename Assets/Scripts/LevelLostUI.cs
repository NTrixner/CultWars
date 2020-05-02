using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLostUI : MonoBehaviour
{
    private void Start()
    {
        GetComponentInChildren<Button>().onClick.AddListener(FindObjectOfType<LevelLoader>().RestartLevel);
    }
}

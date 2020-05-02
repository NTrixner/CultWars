using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelWonUI : MonoBehaviour
{
    private void Start()
    {
        GetComponentInChildren<Button>().onClick.AddListener(FindObjectOfType<LevelLoader>().LoadNextLevel);
    }
}

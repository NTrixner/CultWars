using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public static List<string> levelList = new List<string>()
    {
        "Tutorial", "MainScene"
    };
    public static LevelLoader instance;
    [SerializeField] private string currentLevel;
    [SerializeField] private GameObject lostPanel;
    [SerializeField] private GameObject wonPanel;
    [SerializeField] private GameObject hud;

    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as LevelLoader;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(lostPanel == null)
        {
            lostPanel = GameObject.FindGameObjectWithTag("LostPanel");
            if(lostPanel != null)
            lostPanel.SetActive(false);
        }
        if (wonPanel == null)
        {
            wonPanel = GameObject.FindGameObjectWithTag("WonPanel");
            if (wonPanel != null)
                wonPanel.SetActive(false);
        }
        if (hud == null)
        {
            hud = GameObject.FindGameObjectWithTag("HUD");
            if (hud != null)
                hud.SetActive(true);
        }
        if(currentLevel == null)
        {
            currentLevel = SceneManager.GetActiveScene().name;
        }
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
        currentLevel = level;
        hud.SetActive(true);
        lostPanel.SetActive(false);
        wonPanel.SetActive(false);
    }

    public bool IsLastLevel()
    {
        int levelPos = levelList.FindIndex(x => x == currentLevel);
        return levelPos == levelList.Count - 1;
    }

    public void LoadNextLevel()
    {
        int levelPos = levelList.FindIndex(x => x == currentLevel);
        LoadLevel(levelList[levelPos + 1]);

    }

    public void LostLevel()
    {
        hud.SetActive(false);
        lostPanel.SetActive(true);
    }

    public void WonLevel()
    {
        hud.SetActive(false);
        if(IsLastLevel())
        {
            wonPanel.GetComponentInChildren<Button>().gameObject.SetActive(false);
        }
        wonPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        LoadLevel(currentLevel);
    }
}

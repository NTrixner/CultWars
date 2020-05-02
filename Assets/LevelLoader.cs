using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;
    public bool isPersistant;

    public virtual void Awake()
    {
        if (isPersistant)
        {
            if (!instance)
            {
                instance = this as LevelLoader;
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            instance = this as LevelLoader;
        }
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}

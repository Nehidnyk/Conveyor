using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int level = 0;

    public static LevelManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)//increment level value every time game scene is loaded
    {
        level++;
    }

    private int GetBestLevel()
    {
        return PlayerPrefs.GetInt("BestLevel", 0);
    }

    public void SaveBestLevel()
    {
        if(level > GetBestLevel())
        {
            PlayerPrefs.SetInt("BestLevel", level);
        }
    }
    
}

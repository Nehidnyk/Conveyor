using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Text bestLevelText;

    private void Start()
    {
        PrintBestLevel();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void PrintBestLevel()
    {
        int bestLevel = PlayerPrefs.GetInt("BestLevel", 1);
        bestLevelText.text = $"Best level: {bestLevel}";
    }
}

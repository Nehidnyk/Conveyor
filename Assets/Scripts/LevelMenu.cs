using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] private GameObject finishLevelMenuCanvas;
    [SerializeField] private GameObject failLevelMenuCanvas;



    public void OpenLevelMenu(bool finishLevel)
    {
        if (finishLevel)
            finishLevelMenuCanvas.SetActive(true);
        else
            failLevelMenuCanvas.SetActive(true);
    }

    public void CloseLevelMenu()
    {
        finishLevelMenuCanvas.SetActive(false);
        failLevelMenuCanvas.SetActive(false);
    }


    public void NextLevelHandler()//handler for the "next level" button
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//reload current scene
    }

    public void BackToMenuHandler()//handler for the "back to menu" button
    {
        SceneManager.LoadScene(0);//load menu scene
        Destroy(LevelManager.Instance.gameObject);//destroy level manager object so in next game it will count level from 0
    }
}

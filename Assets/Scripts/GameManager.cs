using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject scriptsObject;
    [SerializeField] private GameObject gameplayCanvas;

    private FoodSpawner foodSpawner;
    private FoodMover foodMover;
    private LevelMenu levelMenu;
    private Countdown countdown;
    private FinalScene finalScene;

    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GetAllComponents();


        foodMover.enabled = false;//disable food mover so the food is not moving until we want it

        countdown.EndOfCountdownEvent += StartGame;//event to know that the countdown is over and we can start game

        countdown.StartCountdown();
    }

    private void GetAllComponents()
    {
        foodSpawner = GameObject.FindObjectOfType<FoodSpawner>();
        levelMenu = GameObject.FindObjectOfType<LevelMenu>();
        countdown = GameObject.FindObjectOfType<Countdown>();
        foodMover = GameObject.FindObjectOfType<FoodMover>();
        finalScene = GameObject.FindObjectOfType<FinalScene>();
    }

    private void StartGame()
    {
        foodSpawner.StartSpawning();
        foodMover.enabled = true;//start moving the food
    }

    public void PassLevel()
    {
        EndOfGame(true);
    }

    public void FailLevel()
    {
        EndOfGame(false);
    }

    private void EndOfGame(bool isLevelPassed)
    {
        gameplayCanvas.SetActive(false);
        scriptsObject.SetActive(false);
        
        LevelManager.Instance.SaveBestLevel();

        levelMenu.OpenLevelMenu(isLevelPassed);
        finalScene.StartFinalScene(isLevelPassed);
    }

    private void OnDestroy()
    {
        countdown.EndOfCountdownEvent -= StartGame;
    }
}

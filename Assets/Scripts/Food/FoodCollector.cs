using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollector : MonoBehaviour
{
    public FoodEnum taskFood;
    public int taskFoodCount = 0;
    private int currentFoodCount = 0;

    public int maxFoodSpawnCount = 0;// if food that player should collect is spawned this amount of time and player doesn't collect enough food, game is over
    private int currentSpawnedFoodSCount = 0;

    private CollectingFoodTextAnimator collectingFoodTextAnimator;
    private Character character;
    private GameplayerOutputer gameplayerOutputer;

    public bool isAbleToCollectFood = true;

    public static FoodCollector Instance;
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
        collectingFoodTextAnimator = GetComponent<CollectingFoodTextAnimator>();

        character = FindObjectOfType<Character>();
        character.FoodInBasketEvent += OnFoodInBasket;//receive notification from character when food was set in the basket

    }

    public void SetTask(FoodEnum taskFood, int taskFoodCount, int maxFoodSpawnCount)//called by task generator class
    {
        gameplayerOutputer = FindObjectOfType<GameplayerOutputer>();

        this.taskFood = taskFood;
        this.taskFoodCount = taskFoodCount;
        this.maxFoodSpawnCount = maxFoodSpawnCount;

        gameplayerOutputer.PrintFoodCount(currentFoodCount, taskFoodCount);
        gameplayerOutputer.PrintSpawnCount(currentSpawnedFoodSCount, maxFoodSpawnCount);
    }

    public void CollectFood(FoodEnum foodName, Food food)
    {
        character.TakeFood(food, foodName);
    }

    private void OnFoodInBasket(FoodEnum foodName)
    {
        if (taskFood == foodName)
        {
            CollectRightFood();
        }
        else
        {
            CollectWrongFood();
        }
    }

    private void CheckPassMission()
    {
        if(currentFoodCount == taskFoodCount)
        {
            GameManager.Instance.PassLevel();
        }
    }

    private void CollectRightFood()
    {
        currentFoodCount++;
        CheckPassMission();
        collectingFoodTextAnimator.StartAnimation();
        gameplayerOutputer.PrintFoodCount(currentFoodCount, taskFoodCount);
    }


    private void CollectWrongFood()
    {
        GameManager.Instance.FailLevel();
    }

    public void CountSpawnedFood()
    {
        currentSpawnedFoodSCount++;
        CheckFailLevel();
        gameplayerOutputer.PrintSpawnCount(currentSpawnedFoodSCount, maxFoodSpawnCount);
    }

    private void CheckFailLevel()
    {
        if(currentSpawnedFoodSCount == maxFoodSpawnCount)
        {
            GameManager.Instance.FailLevel();
        }
    }


    private void OnDestroy()
    {
        character.FoodInBasketEvent -= OnFoodInBasket;

    }
}

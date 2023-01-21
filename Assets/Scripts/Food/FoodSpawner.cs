using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;

    private FoodMover foodMover;

    private System.Random rnd = new System.Random();

    private void Start()
    {
        foodMover = GameObject.FindObjectOfType<FoodMover>();

        Food.StartSensorDetectEvent += SpawnFood;//receive notification that previous food object hit sensor and after that spawn another food.
                                                 //It allow as to spawn food with the same distance, despite food speed
    }

    public void StartSpawning()
    {
        SpawnFood();
    }


    private void SpawnFood()
    {
        GameObject foodObject = FoodPooler.Instance.GetFood(ChooseFood());
        foodObject.transform.position = spawnPosition.position;

        foodMover.AddFoodToList(foodObject);//add spawned food to the food mover list to be moved
    }

    private FoodEnum ChooseFood()//choose random food type
    {
        int index = rnd.Next(System.Enum.GetNames(typeof(FoodEnum)).Length);
        FoodEnum food = (FoodEnum)index;
        return food;
    }

    private void OnDestroy()
    {
        Food.StartSensorDetectEvent -= SpawnFood;

    }
}

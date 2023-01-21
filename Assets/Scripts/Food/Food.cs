using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] public FoodEnum foodName;

    public event RemoveFoodFromListAction RemovefoodFromListEvent;

    public static event System.Action StartSensorDetectEvent;

    public void CollectFood()//is called when food is cliked/touched
    {
        FoodCollector.Instance.CollectFood(foodName, this);
    }

    public void RemoveFood()//return food to the pooler and notify other scripts that it was returned
    {
        FoodPooler.Instance.ReturnFood(foodName, this.gameObject);
        RemovefoodFromListEvent?.Invoke(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FinishSensor"))//if food hit finish sensor, it is returned to the pooler and notify food collector to count spawned food
        {
            RemoveFood();
            if(foodName==FoodCollector.Instance.taskFood)
            {
                FoodCollector.Instance.CountSpawnedFood();
            }
        }
        else if(other.CompareTag("StartSensor"))
        {
            StartSensorDetectEvent?.Invoke();//notify other scripts that food hit start sensor
        }
    }
}

public delegate void RemoveFoodFromListAction(GameObject foodObject);
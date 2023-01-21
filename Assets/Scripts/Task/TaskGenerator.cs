using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskGenerator : MonoBehaviour
{
    [SerializeField] private int foodCountRange;

    private TaskOutputer taskOutputer;
    private System.Random rnd = new System.Random();

    private void Start()
    {
        taskOutputer = GameObject.FindObjectOfType<TaskOutputer>();
        GenerateTask();
    }

    private void GenerateTask()
    {
        FoodEnum food = ChooseFood();
        int foodCount = ChooseCount();

        FoodCollector.Instance.SetTask(food, foodCount, foodCount * 2);

        taskOutputer.OutText(food, foodCount);
        taskOutputer.SetTaskFoodImage(food);
    }

    private FoodEnum ChooseFood()
    {
        int index = rnd.Next(System.Enum.GetNames(typeof(FoodEnum)).Length);
        FoodEnum food = (FoodEnum)index;

        return food;
    }

    private int ChooseCount()
    {
        int count = rnd.Next(1, foodCountRange);
        return count;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskOutputer : MonoBehaviour
{
    [SerializeField] private Text taskText;

    [SerializeField] private Image taskFoodImage;

    //array of sprites in that order: apple, banana, hamburger
    [SerializeField] private Sprite[] foodSprites;

    public void OutText(FoodEnum food, int foodCount)
    {
        string finalTask;
        if (foodCount == 1)
        {
            finalTask = $"Collect {foodCount} {food.ToString()}";
        }
        else
        {
            finalTask = $"Collect {foodCount} {food.ToString()}s";
        }
        
        taskText.text = finalTask;
    }

    public void SetTaskFoodImage(FoodEnum foodName)
    {
        taskFoodImage.sprite = foodSprites[(int)foodName];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class that help replace 3d food object by sprite and position it in the basket
public class FoodTaker : MonoBehaviour
{
    //array of sprites in that order: apple, banana, hamburger
    [SerializeField] private Sprite[] foodSprites;

    [SerializeField] private List<GameObject> foodSpriteObjects;
    [SerializeField] private List<Vector3> placesForSprites;

    private GameObject currentFoodSpriteObject;

    private Food currentFood;

    public void GetFoodSprite(Food food, FoodEnum foodName)//get one of five sprite objects of food(max count of food to collect is 5) and set the right sprite to it
    {
        currentFoodSpriteObject = foodSpriteObjects[0];
        foodSpriteObjects.RemoveAt(0);
        currentFoodSpriteObject.GetComponent<SpriteRenderer>().sprite = foodSprites[(int)foodName];
        currentFood = food;
    }

    public void ReplaceFood()//replace 3d food object by sprite
    {
        currentFood.RemoveFood();//return 3d food object to food pooler

        currentFoodSpriteObject.SetActive(true);
    }

    public void SetFoodOnPlace()//set food sprite to one of five places in the basket
    {
        currentFoodSpriteObject.transform.position = placesForSprites[0];

        currentFoodSpriteObject.GetComponent<FoodSprite>().enabled = false; //disable script attached to food sprite object because it is following hand in update method. We don't need that anymore

        placesForSprites.RemoveAt(0);
    }

    public FoodEnum GetCurrentFoodName()
    {
        return currentFood.foodName;
    }
}

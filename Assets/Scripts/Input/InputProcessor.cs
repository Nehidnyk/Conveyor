using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class process data after getting it from input system: PC, mobile or other
public class InputProcessor : MonoBehaviour
{
    //check whether food is clicked/touched
    public void CheckFoodSelecting(Ray ray)
    {
        RaycastHit raycastHit;
        if(Physics.Raycast(ray, out raycastHit))
        {
            if(raycastHit.collider.CompareTag("Food") && FoodCollector.Instance.isAbleToCollectFood)
            {
                Food food = raycastHit.collider.gameObject.GetComponent<Food>();
                food.CollectFood();

                FoodCollector.Instance.isAbleToCollectFood = false;//prohibit collect the food until it is allowed
            }
        }
    }
}

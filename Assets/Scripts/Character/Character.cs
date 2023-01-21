using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float pullHandTime;

    [SerializeField] private GameObject target;//the hand will follow this target

    [SerializeField] private Vector3 basketPosition;

    private CharacterAnimator characterAnimator;
    private CharacterHead characterHead;

    private FoodTaker foodTaker;

    public event FoodInBasketAction FoodInBasketEvent;

    private void Start()
    {
        characterAnimator = GetComponent<CharacterAnimator>();
        characterHead = GetComponent<CharacterHead>();

        foodTaker = GameObject.FindObjectOfType<FoodTaker>();
    }


    public void TakeFood(Food food, FoodEnum foodName)
    {
        foodTaker.GetFoodSprite(food, foodName);

        LeanTween.move(target, food.gameObject.transform.position, pullHandTime).setOnComplete(PutFood);//pull hand to the selected food and call method "PutFood" after that

        characterHead.RotateHead(food.gameObject.transform.position);
    }

    private void PutFood()
    {
        foodTaker.ReplaceFood();

        LeanTween.move(target, basketPosition, pullHandTime).setOnComplete(SetFoodInBasket);//pull hand to the basket and call method "SetFoodInBasket" after that
    }

    private void SetFoodInBasket()
    {
        foodTaker.SetFoodOnPlace();

        FoodInBasketEvent?.Invoke(foodTaker.GetCurrentFoodName());//notify Food Collector that food is already in the basket

        characterHead.ReturnHead();
        characterAnimator.EnableAnimatorController();

        FoodCollector.Instance.isAbleToCollectFood = true;//allow  collect food
    }
    
}

public delegate void FoodInBasketAction(FoodEnum food);
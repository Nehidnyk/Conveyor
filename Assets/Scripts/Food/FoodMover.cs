using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMover : MonoBehaviour
{
    [SerializeField] private GameObject[] conveyorSurfaceParts = new GameObject[2];

    [SerializeField] private Vector3 movementDirerction;

    [SerializeField] private float startSpeed;
    [SerializeField] private float addedSpeedValue;
    [SerializeField] private float highestSpeed;

    private float speed;

    private List<GameObject> foodOnConveyor = new List<GameObject>();

    private void Start()
    {
        SpeedSetUp();
    }

    private void Update()
    {
        
        MoveFood();
        MoveConveyorSurface();
    }

    private void SpeedSetUp()//determine movement speed in dependence of level
    {
        if(startSpeed + addedSpeedValue*LevelManager.Instance.level <= highestSpeed)
        {
            speed = startSpeed + addedSpeedValue * LevelManager.Instance.level;
        }
        else
        {
            speed = highestSpeed;
        }
    }

    public void AddFoodToList(GameObject foodObject)
    {
        foodOnConveyor.Add(foodObject);
        SubscribeOnRemoveFood(foodObject);
    }

    private void SubscribeOnRemoveFood(GameObject foodObject)
    {
        Food food = foodObject.GetComponent<Food>();
        food.RemovefoodFromListEvent += RemoveFoodFromList;//subscribe to the event when food object should be removed from the list
    }

    public void RemoveFoodFromList(GameObject foodObject)
    {
        foodOnConveyor.Remove(foodObject);

        Food food = foodObject.GetComponent<Food>();
        food.RemovefoodFromListEvent -= RemoveFoodFromList;//unsubscribe to the event so when that food will be added to list again,
                                                           //this script will receive event only once
    }

    private void MoveObject(GameObject object_)
    {
        object_.transform.Translate(movementDirerction * speed * Time.deltaTime, Space.World);

    }

    private void MoveFood()
    {
        foreach(GameObject foodObject in foodOnConveyor)
        {
            MoveObject(foodObject);
        }
    }

    private void MoveConveyorSurface()
    {
        foreach (GameObject conveyorPart in conveyorSurfaceParts)
        {
            MoveObject(conveyorPart);
        }
    }
}

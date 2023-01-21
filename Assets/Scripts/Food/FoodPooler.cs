using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPooler : MonoBehaviour
{
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private GameObject bananaPrefab;
    [SerializeField] private GameObject hamburgerPrefab;

    [SerializeField] private Transform foodParent;


    private Dictionary<FoodEnum, List<GameObject>> pools = new Dictionary<FoodEnum, List<GameObject>>();

    public static FoodPooler Instance;
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
        AddPools();

        CreateStartFood();
    }

    private void AddPools()
    {
        pools.Add(FoodEnum.Apple,
               new List<GameObject>(5));
        pools.Add(FoodEnum.Banana,
            new List<GameObject>(5));
        pools.Add(FoodEnum.Hamburger,
            new List<GameObject>(5));
    }

    private void CreateStartFood()
    {
        // fill apple pool
        for (int i = 0; i < pools[FoodEnum.Apple].Capacity; i++)
        {
            pools[FoodEnum.Apple].Add(GetNewObject(FoodEnum.Apple));
        }

        // fill banana pool
        for (int i = 0; i < pools[FoodEnum.Banana].Capacity; i++)
        {
            pools[FoodEnum.Banana].Add(GetNewObject(FoodEnum.Banana));
        }

        // fill hamburger pool
        for (int i = 0; i < pools[FoodEnum.Hamburger].Capacity; i++)
        {
            pools[FoodEnum.Hamburger].Add(GetNewObject(FoodEnum.Hamburger));
        }
    }

    public GameObject GetFood(FoodEnum name)
    {
        List<GameObject> pool = pools[name];

        // check for available object in pool
        if (pool.Count > 0)
        {
            // remove object from pool and return
            GameObject obj = pool[pool.Count - 1];
            pool.RemoveAt(pool.Count - 1);

            obj.SetActive(true);
            return obj;
        }
        else
        {

            // pool empty, so expand pool and return new object
            pool.Capacity++;
            pool.Add(GetNewObject(name));
            return GetFood(name);
        }
    }


    public void ReturnFood(FoodEnum name, GameObject food)
    {
        food.SetActive(false);
        pools[name].Add(food);
    }

    private GameObject GetNewObject(FoodEnum name)
    {
        GameObject obj;
        if (name == FoodEnum.Apple)
        {
            obj = GameObject.Instantiate(applePrefab, foodParent);
        }
        else if(name == FoodEnum.Banana)
        {
            obj = GameObject.Instantiate(bananaPrefab, foodParent);
        }
        else
        {
            obj = GameObject.Instantiate(hamburgerPrefab, foodParent);
        }
        obj.SetActive(false);
        return obj;
    }

}

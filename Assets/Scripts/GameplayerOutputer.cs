using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayerOutputer : MonoBehaviour
{
    [SerializeField] private Text foodCountText;
    [SerializeField] private Text spawnCountText;


    public void PrintFoodCount(int currentFoodCount, int taskFoodCount)
    {
        foodCountText.text = $"{currentFoodCount}/{taskFoodCount}";
    }

    public void PrintSpawnCount(int currentSpawnCount, int maxSpawnCount)
    {
        spawnCountText.text = $"Spawns: {currentSpawnCount}/{maxSpawnCount}";
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is attached to food sprite objects and after object is at his place this component will be disabled
public class FoodSprite : MonoBehaviour
{
    [SerializeField] private Transform hand;
    void Update()
    {
        FollowHand();
    }

    private void FollowHand()
    {
        transform.position = hand.position;
    }
}

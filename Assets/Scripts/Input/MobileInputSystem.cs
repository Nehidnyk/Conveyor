using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInputSystem : MonoBehaviour
{
    private InputProcessor inputProcessor;

    private void Start()
    {
        inputProcessor = GetComponent<InputProcessor>();
    }

    private void Update()
    {
        if (Input.touchCount>0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            inputProcessor.CheckFoodSelecting(ray);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCInputSystem : MonoBehaviour
{
    private InputProcessor inputProcessor;

    private void Start()
    {
        inputProcessor = GetComponent<InputProcessor>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            inputProcessor.CheckFoodSelecting(ray);
        }
    }

}

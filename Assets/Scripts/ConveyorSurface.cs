using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSurface : MonoBehaviour
{
    [SerializeField] private GameObject anotherSurfacePart;

    private void SetAnotherPartBehind()
    {
        anotherSurfacePart.transform.position = new Vector3(this.transform.position.x - (this.transform.localScale.y), anotherSurfacePart.transform.position.y, anotherSurfacePart.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)//when when conveyor surface object trigger enter sensor, another part of conveyor surface is set behind, so we get infinite movement
    {
        if(other.CompareTag("ConveyorSensor"))
        {
            SetAnotherPartBehind();
        }
    }
}

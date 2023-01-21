using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHead : MonoBehaviour
{
    [SerializeField] private GameObject head;

    private CharacterAnimator characterAnimator;

    private void Start()
    {
        characterAnimator = GetComponent<CharacterAnimator>();
    }

    public void RotateHead(Vector3 targetPosition)
    {
        // characterAnimator.StopIdleAnimation();//stop idle animation while rotating
        characterAnimator.DisableAnimatorController();

        float yRotation = CalculateAngle(targetPosition);
        head.transform.rotation = Quaternion.Euler(new Vector3(10, yRotation, 0));
    }

    public void ReturnHead()//return head to start position
    {
        head.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    private float CalculateAngle(Vector3 targetPosition)//calculate what angle head should be rotated to look at the selected food
    {
        float sideA = targetPosition.x;
        float sideB = targetPosition.z;

        float angle = (float)System.Math.Atan(sideA / sideB);

        angle *= (180 / 3.14f);//convert from radian to degrees

        return angle;

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CharacterAnimator : MonoBehaviour
{
    private Animator animator;
    private RigBuilder rigBuilder;

    [SerializeField] private RuntimeAnimatorController runtimeAnimatorController;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rigBuilder = GetComponent<RigBuilder>();
    }

    public void EnableAnimatorController()//enable animator controller, so that we can controll character by animator
    {
        if(animator.runtimeAnimatorController!=runtimeAnimatorController)
        {
            animator.runtimeAnimatorController = runtimeAnimatorController;
        }
    }

    public void DisableAnimatorController()//disable animator controller, so that we can rotate head by script
    {
        animator.runtimeAnimatorController = null;
    }

    public void EnableRigging()
    {
        rigBuilder.enabled = true;
    }

    public void DisableRigging()
    {
        rigBuilder.enabled = false;
    }

    public void PlayDancingAnimation()
    {
        animator.SetBool("Dance", true);
    }

    public void PlaySadAnimation()
    {
        animator.SetBool("BeSad", true);
    }
}

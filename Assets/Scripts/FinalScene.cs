using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.VFX;

public class FinalScene : MonoBehaviour
{
    [SerializeField] private PlayableDirector timeline;

    [SerializeField] private VisualEffect[] confettiEffects;
    [SerializeField] private float confettiFrequency = 5;

    private CharacterAnimator characterAnimator;

    [SerializeField] private GameObject foodObjects;
    [SerializeField] private GameObject basketObject;


    private void Start()
    {
        characterAnimator = GameObject.FindObjectOfType<CharacterAnimator>();
    }


    public void StartFinalScene(bool isLevelPassed)
    {
        timeline.Play();

        DisableUnwantedObjects();

        characterAnimator.EnableAnimatorController();
        characterAnimator.DisableRigging();

        if(isLevelPassed)
        {
            characterAnimator.PlayDancingAnimation();
            EffectSetup(100); //spawn 100 particle of the effect          
        }
        else
        {
            characterAnimator.PlaySadAnimation();
            EffectSetup(1);//spawn 1 particle of the effect
        }

    }

    private void EffectSetup(int spawnCount)
    {
        foreach (VisualEffect effect in confettiEffects)
        {
            effect.SetInt("SpawnCount", spawnCount);
            StartCoroutine(PlayEffect(effect));
        }
    }

    private IEnumerator PlayEffect(VisualEffect effect)//play effect every n seconds
    {
        while (true)
        {
            effect.Play();
            yield return new WaitForSeconds(confettiFrequency);
        }
    }

    private void DisableUnwantedObjects()
    {
        foodObjects.SetActive(false);
        basketObject.SetActive(false);
    }
}

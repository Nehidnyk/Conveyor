using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectingFoodTextAnimator : MonoBehaviour
{
    [SerializeField] private Text collectingFoodText;
    [SerializeField] private Vector3 startTextPosition;
    [SerializeField] private Vector3 finalTextPosition;
    [SerializeField] private float moveUpTime;
    [SerializeField] private float fadingTime;


    public void StartAnimation()//reset text position and change color alpha, because it is 0 after fading
    {
        collectingFoodText.rectTransform.anchoredPosition = startTextPosition;

        Color color = collectingFoodText.color;
        color.a = 1;
        collectingFoodText.color = color;

        AnimateText();
    }

    private void AnimateText()
    {
        LeanTween.move(collectingFoodText.rectTransform, finalTextPosition, moveUpTime).setOnComplete(TextFading);
    }

    private void TextFading()
    {
        LeanTween.alphaText(collectingFoodText.rectTransform, 0f, fadingTime);
    }
}

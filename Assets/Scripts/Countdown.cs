using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] Vector2 countdownTextScaledSize;

    private string[] countdownTexts = new string[3];

    public event System.Action EndOfCountdownEvent;

    private void Start()
    {
        FillCountdownTexts();
    }

    private void FillCountdownTexts()
    {
        countdownTexts[0] = "Ready";
        countdownTexts[1] = "Set";
        countdownTexts[2] = "GO!";
    }

    public void StartCountdown()
    {
        StartCoroutine(Countdown_());
    }

    private IEnumerator Countdown_()
    {
        countdownText.gameObject.SetActive(true);

        for (int i = 0; i < 3; i++)//change countdown text and play animation every second 3 times
        {
            countdownText.text = countdownTexts[i];
            countdownText.rectTransform.localScale = new Vector3(1, 1, 1);
            AnimateText();
            yield return new WaitForSeconds(1);
        }

        countdownText.gameObject.SetActive(false);
        EndOfCountdownEvent?.Invoke();
    }

    private void AnimateText()
    {
        LeanTween.scale(countdownText.rectTransform, countdownTextScaledSize, 1);
    }
}

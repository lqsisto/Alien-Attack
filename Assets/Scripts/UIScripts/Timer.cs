using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    static Timer t;

    static Text countdownText;
    private void Awake ()
    {
        countdownText = UIController.TimerText.GetComponent<Text>();
        t = this;
    }

    public static void StartTimer (int countdownSecs)
    {
        t.StartCoroutine (Countdown (countdownSecs));
    }

    static IEnumerator Countdown (int countdownSecs)
    {
        while (countdownSecs > -1)
        {
            countdownText.text = countdownSecs.ToString ();
            yield return new WaitForSecondsRealtime (1);
            countdownSecs--;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : GameManager
{

    private void Awake ()
    {
        countdownText = UIController.TimerText.GetComponent<Text> ();
    }

    public IEnumerator Countdown (int countdownSecs)
    {
        print ("inside timer");
        PausemenuController.gamePaused = true;
        while (countdownSecs > 0)
        {
            countdownText.text = countdownSecs.ToString ();
            yield return new WaitForSecondsRealtime (1);
            countdownSecs--;
        }
        PausemenuController.gamePaused = false;
        UIController.ToggleCountdownPanel();
    }
}
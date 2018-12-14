using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Luminosity.IO;
public class PausemenuController : MonoBehaviour
{

    public GameObject pausemenuCanvas;

    public bool start_Countdown;
    public static bool gamePaused;
    float currCountdownValue;
    public GameObject paused;
    public GameObject buttonFrame;
    public Text timerText;
    float timer;

    public int continueGameWait;

    // Use this for initialization
    void Start()
    {

        timer = 3.0f;
        start_Countdown = false;

        if(timerText.gameObject.activeInHierarchy)
        {
            timerText.gameObject.SetActive(false);
        }

        if (pausemenuCanvas.activeInHierarchy)
        {
            pausemenuCanvas.SetActive(false);
        }

        gamePaused = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.GetKeyDown(KeyCode.P))
        {
            pausemenuCanvas.SetActive(true);
            gamePaused = true;
            if (timerText.gameObject.activeInHierarchy)
            {
                timerText.gameObject.SetActive(false);
            }
            Time.timeScale = 0;
        }
    }

    public void ResumeGame()
    {
        paused.SetActive(false);
        buttonFrame.SetActive(false);
        timerText.gameObject.SetActive(true);
        start_Countdown = true;
        timerText.text = continueGameWait.ToString();
        StartCountdown();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Break();
    }

    public void StartCountdown()
    {
        if (start_Countdown)
        {
            StartCoroutine(StartCountdownCoroutine());
            start_Countdown = false;
        }
    }

    public IEnumerator StartCountdownCoroutine()
    {
        currCountdownValue = continueGameWait;
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSecondsRealtime(1);
            currCountdownValue--;
            timerText.text = currCountdownValue.ToString();
        }

        Time.timeScale = 1;
        paused.SetActive(true);
        gamePaused = false;
        buttonFrame.SetActive(true);
        timerText.gameObject.SetActive(true);
        if (pausemenuCanvas.activeInHierarchy)
        {
            pausemenuCanvas.SetActive(false);
        }

    }
}

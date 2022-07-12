using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScoreSystems : MonoBehaviour
{
    [Header("Score Systems")]
    [SerializeField] Text scoreText;
    [SerializeField] public int score = 50000;

    [Header("Timer Systems")]
    [SerializeField] Text timerText;
    [SerializeField] public float initialTimer;

    [Header("Audio Systems")]
    [SerializeField] AudioSource audioSource;

    [Header("Failure Systems")]
    [SerializeField] GameObject gamePlaySystems;
    [SerializeField] GameObject failureScreenCanvas;

    // Start is called before the first frame update
    void Awake()
    {
        Invoke("GetMusicTime", 0.05f);
    }

    void GetMusicTime()
    {
        initialTimer = audioSource.clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "$" + $@"{score}";
        initialTimer -= Time.deltaTime;
        DisplayTimer(initialTimer);

        if (initialTimer < -0.1f)
        {
            failureScreenCanvas.SetActive(true);
            Destroy(gamePlaySystems);
        }
    }

    void DisplayTimer(float displayTime)
    {
        displayTime += 1;
        float minutes = Mathf.FloorToInt(displayTime / 60);
        float seconds = Mathf.FloorToInt(displayTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

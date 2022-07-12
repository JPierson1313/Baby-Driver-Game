using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreenSystems : MonoBehaviour
{
    [Header("Win Screen Systems")]
    [SerializeField] Text scoreText;
    [SerializeField] Text timeText;

    [Header("Timer Score Systems")]
    [SerializeField] GameObject gamePlaySystems;
    [SerializeField] TimerScoreSystems timerScoreSystems;

    // Start is called before the first frame update
    void Start()
    {
        timerScoreSystems = GameObject.FindGameObjectWithTag("TimerScore").GetComponent<TimerScoreSystems>();
        gamePlaySystems = GameObject.FindGameObjectWithTag("Gameplay");
        scoreText.text = "Money Left: $" + $@"{timerScoreSystems.score}";
        timeText.text = "Time Left: " + $@"{timerScoreSystems.initialTimer:F0}" + " seconds";
        Destroy(gamePlaySystems);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameObject.activeInHierarchy)
        {
            RestartButton();
        }
    }

    public void RestartButton()
    {
       if (gameObject.activeInHierarchy == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

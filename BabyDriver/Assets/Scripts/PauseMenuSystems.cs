using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuSystems : MonoBehaviour
{
    [Header("Pause Menu Systems")]
    [SerializeField] GameObject pauseMenuCanvas;
    [SerializeField] AudioSource audioSource;
    private int pauseNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (pauseNum)
        {
            case 2:
                Time.timeScale = 0;
                audioSource.Pause();
                pauseMenuCanvas.SetActive(true);
                break;
            
            case 3:
                Time.timeScale = 1;
                pauseNum = 1;
                audioSource.UnPause();
                pauseMenuCanvas.SetActive(false);
                break;
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            PauseButton();
        }
    }

    public void PauseButton()
    {
        pauseNum++;
    }
}

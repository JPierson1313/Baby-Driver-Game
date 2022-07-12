using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenSystems : MonoBehaviour
{
    [Header("Title Screen Systems")]
    [SerializeField] GameObject titleScreenGroup;

    [Header("Game Screen Systems")]
    [SerializeField] GameObject gameScreenGroup;

    [Header("Audio Systems")]
    [SerializeField] AudioSystems audioSystems;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PlayButton();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitButton();
        }
    }

    public void PlayButton()
    {
        audioSystems.switchingTracks = true;
        gameScreenGroup.SetActive(true);  
        titleScreenGroup.SetActive(false);
        Destroy(gameObject);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}

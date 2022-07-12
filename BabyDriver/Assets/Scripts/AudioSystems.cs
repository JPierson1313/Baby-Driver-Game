using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSystems : MonoBehaviour
{
    [Header("Audio Systems")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] Slider volumeSlider;

    [Header("Audio Tracks")]
    [SerializeField] AudioClip startScreenMusic;
    [SerializeField] AudioClip gameScreenMusic;
    [HideInInspector] public bool switchingTracks = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = startScreenMusic;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = volumeSlider.value;
        if (switchingTracks)
        {
            audioSource.clip = gameScreenMusic;
            audioSource.Play();
            switchingTracks = false;
        }
    }
}

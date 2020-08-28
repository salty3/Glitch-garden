using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider difficultySlider;
    [SerializeField][Range(0, 1)] private float defaultVolume = 0.5f;
    [SerializeField][Range(1, 3)] private float defaultDifficulty = 1;

    private MusicPlayer musicPlayer;
    private void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
        musicPlayer = FindObjectOfType<MusicPlayer>();
    }
    
    private void Update()
    {
        SetVolume();
        SetDifficulty();
    }

    private void SetDifficulty()
    {
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
    }

    private void SetVolume()
    {
        if (musicPlayer)
        {
            PlayerPrefsController.SetMasterVolume(volumeSlider.value);
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogError("No music player found");
        }
    }

    public void SetDefault()
    {
        volumeSlider.value = defaultVolume;
        PlayerPrefsController.SetMasterVolume(defaultVolume);

        difficultySlider.value = defaultDifficulty;
        PlayerPrefsController.SetDifficulty(defaultDifficulty);
    }
}

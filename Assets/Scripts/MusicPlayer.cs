using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private int is_mus_play = 1;

    // Start is called before the first frame update
    void Start()
    {
        is_mus_play = PlayerPrefs.GetInt("Mus_play", 1);
        if (is_mus_play == 1)
        {
            GetComponent<AudioSource>().mute = false;
        }
        else
        {
            GetComponent<AudioSource>().mute = true;
        }
    }

    public void PlayPause()
    {
        if (is_mus_play == 1)
        {
            is_mus_play = 0;
            PlayerPrefs.SetInt("Mus_play", 0);
            GetComponent<AudioSource>().mute = true;
        }
        else
        {
            is_mus_play = 1;
            PlayerPrefs.SetInt("Mus_play", 1);
            GetComponent<AudioSource>().mute = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    private AudioSource currentMusicSource;
    private bool isMusicMutedbool = false;

    public void setCurrentMusic(AudioSource musicSource)
    {
        currentMusicSource = musicSource;

        if(isMusicMutedbool)
        {
            currentMusicSource.Pause();
        }

        else
        {
            currentMusicSource.Play();  
        }
    }

    public void toggleMusic()
    {
        isMusicMutedbool = !isMusicMutedbool;

        if(currentMusicSource != null)
        {
            if(isMusicMutedbool )
            {
                currentMusicSource.Pause();
            }

            else
            {
                currentMusicSource.Play();
            }
        }
    }

    public bool isMusicMuted()
    {
        return isMusicMutedbool;
    }

}

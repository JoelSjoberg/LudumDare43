using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound{

    public AudioClip clip;
    [HideInInspector]public AudioSource source;

    public string name;

    [Range(0.0f, 5.0f)]
    public float pitch;
    [Range(0.0f, 2.0f)]
    public float volume;

    public bool looping, play_on_start, is_bgm, playing;

    public void play()
    {
        
        source.Play();
    }

    public IEnumerator fadein()
    {
        while (volume < 1)
        {

            Debug.Log("increasing volume: " + volume);
            
            volume += 0.1f;
            source.volume = volume;
            yield return new WaitForEndOfFrame();
        }
    }

    public void stop()
    {
        playing = false;
        source.Stop();
    }
}

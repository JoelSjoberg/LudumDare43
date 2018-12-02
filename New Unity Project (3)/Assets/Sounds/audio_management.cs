using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class audio_management : MonoBehaviour {

    public Sound[] sounds;

	// Use this for initialization
	void Start () {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.looping;

            if (s.play_on_start && s.is_bgm)
            {
                s.source.Play();
            }
        }
	}

    public void fadeIn(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) Debug.Log("The sound " + name + " does not exist.");
        else
        {
            if(!s.playing)
            {
                StartCoroutine(s.fadein());
                s.playing = true;
            }

        }

    }

    public void play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) Debug.Log("The sound " + name + " does not exist.");
        else s.source.Play();

    }
}

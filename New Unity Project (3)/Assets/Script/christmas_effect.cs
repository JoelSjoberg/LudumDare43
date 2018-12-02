using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class christmas_effect : MonoBehaviour {

    bool started = false;
    [SerializeField]ParticleSystem snow;

	// Use this for initialization
	void Start () {
        started = false;
	}

    public void startEffect()
    {
        if(!started)
        {
            Instantiate(snow, transform);
            started = true;
        }
    }
}

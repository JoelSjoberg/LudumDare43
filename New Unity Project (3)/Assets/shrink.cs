using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrink : MonoBehaviour {

    Animator anim;
    Animation shrink_anim;
    [SerializeField] float small_duration;

    [SerializeField] Vector3 shrink_size;

	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        shrink_anim = GetComponent<Animation>();
	}

    public void doShrink()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, shrink_size, 1);
    }

    void doEnlarge()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, 1);
    }

}

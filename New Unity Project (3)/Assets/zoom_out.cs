using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom_out : MonoBehaviour {

    bool toggle = false;
    Camera cam;
    public float amount = 100;
    public float norm = 60;
	// Use this for initialization
	void Start ()
    {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.M))
        {
            toggle = !toggle;
            if (toggle) StartCoroutine(_out());
            else StartCoroutine(_in());
        }
    }

    IEnumerator _out()
    {
        while (cam.fieldOfView < amount)
        {
            cam.fieldOfView += 0.5f;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator _in()
    {
        while (cam.fieldOfView > norm)
        {
            cam.fieldOfView -= 0.5f;
            yield return new WaitForEndOfFrame();
        }
    }
}

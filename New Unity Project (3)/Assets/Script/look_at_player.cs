using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look_at_player : MonoBehaviour {

    levelsetup playerHolder;
    Transform target;

    cam_shake shaker;
    Camera cam;
    spawn_script spawn;
	// Use this for initialization
	void Start () {
        shaker = GetComponent<cam_shake>();
        cam = GetComponent<Camera>();
        cam.fieldOfView = 130;
        playerHolder = FindObjectOfType<levelsetup>();
        StartCoroutine(zoomIn());

        spawn = FindObjectOfType<spawn_script>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerHolder.getActivePlayer() != null)
        {

            target = playerHolder.getActivePlayer();
            if (target.GetComponent<Rigidbody>().velocity.magnitude > 0.2)
            {
                transform.position = Vector3.Lerp(transform.position, getTargetLerp(target), 0.5f);
            }
            else if (Mathf.Abs((target.position - transform.position).magnitude) > 1)
            {
                transform.position = Vector3.Lerp(transform.position, getTargetLerp(target), 0.5f);
            }
            transform.LookAt(playerHolder.getActivePlayer());
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, getTargetLerp(spawn.transform), 0.5f);
        }
	}

    Vector3 getTargetLerp(Transform t)
    {
        return new Vector3(t.position.x, transform.position.y, transform.position.z);
    }
    IEnumerator zoomIn()
    {
        
        while (cam.fieldOfView > 60)
        {
            cam.fieldOfView -= 0.2f;
            yield return new WaitForEndOfFrame();
        }
    }
}

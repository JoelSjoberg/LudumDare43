using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look_at_player : MonoBehaviour {

    levelsetup playerHolder;
    Transform target;
	// Use this for initialization
	void Start () {
        playerHolder = FindObjectOfType<levelsetup>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerHolder.getActivePlayer() != null)
        {
            target = playerHolder.getActivePlayer();
            transform.position = Vector3.Lerp(transform.position, getTargetLerp(target), 1);
            transform.LookAt(playerHolder.getActivePlayer());
        }
	}

    Vector3 getTargetLerp(Transform t)
    {
        return new Vector3(t.position.x, transform.position.y, transform.position.z);
    }
}

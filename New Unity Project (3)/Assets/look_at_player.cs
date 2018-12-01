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
        target = playerHolder.getActivePlayer();
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        transform.LookAt(playerHolder.getActivePlayer());
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look_at_player : MonoBehaviour {

    levelsetup playerHolder;

	// Use this for initialization
	void Start () {
        playerHolder = FindObjectOfType<levelsetup>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(playerHolder.getActivePlayer());
	}
}

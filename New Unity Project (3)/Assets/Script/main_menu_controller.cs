﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class main_menu_controller : MonoBehaviour {

    public string nextLevel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(nextLevel);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launch : MonoBehaviour {

    Rigidbody rb;
    [SerializeField] float speed;
    state_script state;

	// Use this for initialization
	void Start ()
    {
        state = GetComponent<state_script>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !state.getLaunched() && !state.getDead())
        {
            rb.AddForce(transform.right * speed);
            state.setLaunched(true);
        }
    }



}

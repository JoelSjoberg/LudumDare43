using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_to_velocity : MonoBehaviour {

    Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.right = Vector3.Lerp(transform.right, rb.velocity, 1);
    }
}

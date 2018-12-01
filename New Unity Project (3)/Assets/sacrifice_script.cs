using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sacrifice_script : MonoBehaviour {

    public delegate void onDeath();
    public onDeath die;

    state_script state;

    Rigidbody rb;

    [SerializeField] bool no_gravity_on_death;
    [SerializeField] bool stop_on_death;

    SphereCollider sc;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        state = GetComponent<state_script>();
        die += stopMoving;
        sc = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.K) && state.getLaunched() && !state.getDead())
        {
            die();
            state.setDead(true);
        }
	}


    void stopMoving()
    {
        rb.useGravity = !no_gravity_on_death;
        if (stop_on_death) rb.velocity = Vector3.zero;
        sc.isTrigger = true;
    }

}

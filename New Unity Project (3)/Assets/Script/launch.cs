using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launch : MonoBehaviour {

    Rigidbody rb;
    [SerializeField] float speed;
    state_script state;
    float tuner = 0.5f;
    float max_tuner_value = 1.0f;
    float min_tuner_value = 0.4f;
    float tuner_adder = 0.01f;
    cam_shake cam;

    audio_management audio;
    // wait x amount of seconds before shooting away
    float timer = 0;
    float wait_time = 1;

	// Use this for initialization
	void Start ()
    {
        timer = 0;
        tuner = min_tuner_value;
        state = GetComponent<state_script>();
        rb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<cam_shake>();
        audio = FindObjectOfType<audio_management>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(timer < wait_time)
        {
            timer += Time.deltaTime;
        }
        else
        {
            if (!state.getLaunched() && !state.getDead())
            {
                if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
                {

                    cam.shake(tuner * 0.5f);
                    tuner += tuner_adder;
                    if (tuner > max_tuner_value)
                    {

                        tuner = max_tuner_value;
                        tuner_adder *= -1;
                    } else if (tuner < min_tuner_value)
                    {
                        tuner = min_tuner_value;
                        tuner_adder *= -1;
                    }
                }

                if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
                {
                    state.num_launches += 1;
                    audio.play("boost");
                    rb.AddForce(transform.right * speed * tuner);
                    state.setLaunched(true);

                }
            }
        }
    }
}

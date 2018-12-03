using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_script : MonoBehaviour {

    state_script state;

    audio_management audio;

    [SerializeField] float upwards_force = 500;
    [SerializeField] float boost_force = 500;

    [SerializeField] bool collided;
    private void Awake()
    {
        state = GetComponent<state_script>();
        audio = FindObjectOfType<audio_management>();
        collided = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && state.getDead() && !collided)
        {
            collided = false;
            switch (state.type)
            {
                case ballType.bounce:
                    bounce(other.transform);
                    break;

                case ballType.boost:
                    boost(other.transform);
                    break;

                case ballType.secondWind:
                    secondWind(other.transform);
                    break;

                case ballType.shrink:
                    shrink(other.transform);
                    break;

                case ballType.christmas:
                    christmas(other.transform);
                    break;
                default:
                    Debug.Log("unimplemented balltype");
                    break;
            }
        }
    }

    // if balltype is bounce, add force upwards
    void bounce(Transform t)
    {
        audio.play("bounce");
        audio.fadeIn("ominous");
        t.GetComponent<Rigidbody>().AddForce(Vector3.up * upwards_force);
    }

    // balltype = boost
    void boost(Transform t)
    {
        audio.play("boost");
        audio.fadeIn("saturn");
        t.GetComponent<Rigidbody>().AddForce(Vector3.right *boost_force);
    }

    void secondWind(Transform t)
    {
        audio.fadeIn("echoes");
        t.GetComponent<state_script>().setLaunched(false);
    }

    void shrink(Transform t)
    {
        audio.play("shrink");
        audio.fadeIn("piano");
        t.GetComponent<shrink>().doShrink();
    }

    void christmas(Transform t)
    {
        audio.fadeIn("christmas");
        t.GetComponent<christmas_effect>().startEffect();
    }
}

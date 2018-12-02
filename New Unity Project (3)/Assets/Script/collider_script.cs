using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_script : MonoBehaviour {

    state_script state;

    [SerializeField] float upwards_force = 500;
    [SerializeField] float boost_force = 500;

    [SerializeField] bool collided;
    private void Awake()
    {
        state = GetComponent<state_script>();
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
        Debug.Log("bounce");
        t.GetComponent<Rigidbody>().AddForce(t.up * upwards_force);
    }

    // balltype = boost
    void boost(Transform t)
    {
        Debug.Log("boost");
        t.GetComponent<Rigidbody>().AddForce(t.right *boost_force);
    }

    void secondWind(Transform t)
    {
        Debug.Log("Second wind");
        t.GetComponent<state_script>().setLaunched(false);
    }

    void shrink(Transform t)
    {
        Debug.Log("Shrink");
        t.GetComponent<shrink>().doShrink();
    }

    void christmas(Transform t)
    {
        Debug.Log("DO CHRISTMAS");
    }
}

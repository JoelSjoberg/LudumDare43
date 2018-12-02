using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrink : MonoBehaviour {

    [SerializeField] Vector3 shrink_size;


    public void doShrink()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, shrink_size, 1);
    }

    void doEnlarge()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, 1);
    }

}

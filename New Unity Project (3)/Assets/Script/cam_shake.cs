using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_shake : MonoBehaviour {



    public void shake(float intensity)
    {
        Vector3 s = Random.insideUnitSphere;
        s.z = 0;
        transform.position += s * intensity;
    }
}

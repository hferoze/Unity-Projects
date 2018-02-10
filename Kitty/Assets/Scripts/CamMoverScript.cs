using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoverScript : MonoBehaviour {

    public Transform pos1, pos2;
    public float speed = 1;

    // Update is called once per frame
    void Update () {
        float pingPong = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pos1.position, pos2.position, pingPong);
    }
}

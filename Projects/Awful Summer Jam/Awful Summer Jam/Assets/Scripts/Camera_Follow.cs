using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour {

    public GameObject target;
    public float smooth_speed;
    public float xOffset;
	
	void Update () {

        transform.position = new Vector3 (Mathf.Lerp(transform.position.x, target.transform.position.x + xOffset, smooth_speed),0,-10);

	}
}

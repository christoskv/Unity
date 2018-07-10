using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck_Controller : MonoBehaviour {

    Rigidbody2D rb;
    public float upForce;
    public float speed;

	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            rb.isKinematic = false;
            rb.velocity = new Vector2(speed, upForce);
        }
	}
}

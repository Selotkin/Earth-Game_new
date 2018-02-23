using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFalling : MonoBehaviour {

	public GameObject explosionEffect;

    private Rigidbody rigid;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rigid.AddForce(-transform.position, ForceMode.Acceleration);
	}

    private void OnCollisionEnter(Collision collision)
    {	
		if (collision.collider.tag != "Meteor") {
			Instantiate (explosionEffect, transform.position, transform.rotation);
			Destroy(gameObject);
		}	
    }
}

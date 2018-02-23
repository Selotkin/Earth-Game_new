using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityPlayer : MonoBehaviour {

    public FauxGravity fauxGravity;

    private Rigidbody myRigidbody;
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        myRigidbody.useGravity = false;
    }

    private void Update()
    {
        fauxGravity.Attract(myRigidbody);
    }
}

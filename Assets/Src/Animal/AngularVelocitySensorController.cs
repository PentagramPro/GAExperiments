using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngularVelocitySensorController : MonoBehaviour {

	SensorController sensor;
	new Rigidbody2D rigidbody;
	// Use this for initialization
	void Start () {
		sensor = GetComponent<SensorController>();
		rigidbody = GetComponentInParent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		sensor.Signal = rigidbody.angularVelocity;
	}
}

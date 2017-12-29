using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocitySensorController : MonoBehaviour {

	SensorController sensor;
	Vector3 lastPosition;
	// Use this for initialization
	void Start () {
		sensor = GetComponent<SensorController>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vel = (transform.position - lastPosition)*Time.deltaTime;
		sensor.Signal = vel.magnitude;

		lastPosition = transform.position;
	}
}

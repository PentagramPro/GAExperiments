﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSensorController : MonoBehaviour {

	SensorController sensor;
	public float MaxDistance = 10;

	// Use this for initialization
	void Start () {
		sensor = GetComponent<SensorController>();
		sensor.Signal = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void OnTriggerStay2D(Collider2D collision)
	{
		var sensorTarget = collision.gameObject.GetComponent<SensorTargetController>();

		if (sensorTarget == null)
		{
			return;
		}

		float distance = (transform.position - sensorTarget.transform.position).magnitude;
		distance = Mathf.Clamp(distance, 0, MaxDistance);
		sensor.Signal = 1 - distance / MaxDistance;
	}


	private void OnTriggerExit2D(Collider2D collision)
	{
		if (sensor == null)
			return;
		sensor.Signal = 0;
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorController : MonoBehaviour {

    public float Signal { get; private set; }
	public float MaxSignal = 1;
	public float MaxDistance = 10;
	// Use this for initialization
	void Start () {
		
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
		Signal = 1 - distance / MaxDistance;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{

	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		Signal = 0;
	}




}

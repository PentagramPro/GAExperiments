using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensorMonitorController : MonoBehaviour {

	public SensorController Sensor;
	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();	
	}
	
	// Update is called once per frame
	void Update () {
        if(Sensor!=null)
		    text.text = string.Format("{0}", Sensor.Signal);
	}
}

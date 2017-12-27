using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorController : MonoBehaviour {

    public float Signal { get; private set; }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        var sensorTarget = collision.gameObject.GetComponent<SensorTargetController>();

        if(sensorTarget == null)
        {
            return;
        }

        Signal = (transform.position - sensorTarget.transform.position).magnitude;
    }


}

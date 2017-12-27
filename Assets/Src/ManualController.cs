using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManualController : MonoBehaviour {

	public ActuatorController Left, Right;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
		if(Input.GetKey(KeyCode.Q))
        {
			Left.SetForce(1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
			Left.SetForce(-1);
        }
        if (Input.GetKey(KeyCode.W))
        {
			Right.SetForce(1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
			Right.SetForce(-1);
        }
		
    }
}

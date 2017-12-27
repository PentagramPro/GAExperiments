using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManualController : MonoBehaviour {

    public float Speed = 3;
    public float RotationSpeed = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float velocity = 0;
        float rotation = 0;
		if(Input.GetKey(KeyCode.UpArrow))
        {
            velocity = Speed * Time.smoothDeltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity =- Speed * Time.smoothDeltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotation += RotationSpeed * Time.smoothDeltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotation -= RotationSpeed * Time.smoothDeltaTime;
        }

        transform.Rotate(Vector3.forward, rotation);
        Debug.Log(transform.right);
        transform.position += transform.right * velocity;

    }
}

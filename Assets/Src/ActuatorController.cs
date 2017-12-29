using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActuatorController : MonoBehaviour {

	public float Force = 5;
	new Rigidbody2D rigidbody;
	Vector3 vectorOne = new Vector3(1, 0, 0);
	Vector3 lastAppliedForce;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponentInParent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, 0.4f);
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position + vectorOne, 0.3f);
		Gizmos.DrawLine(transform.position, transform.position + lastAppliedForce);
	}

	public void SetForce(float amount)
	{
        if (rigidbody == null)
            return;
		amount = Mathf.Clamp(amount,-1,1);
		var forceVector = transform.TransformVector(vectorOne).normalized*Force*amount;
		rigidbody.AddForceAtPosition(forceVector, transform.position);
		lastAppliedForce = forceVector;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour {

    public int Eaten { get; private set; }
	// Use this for initialization
	void Start () {
        Eaten = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var target = collision.gameObject.GetComponent<SensorTargetController>();
        if (target == null)
            return;

        Destroy(target.gameObject);
        Eaten++;
    }


}

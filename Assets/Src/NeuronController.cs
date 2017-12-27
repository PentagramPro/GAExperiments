using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AForge.Neuro;

public class NeuronController : MonoBehaviour {

    ActivationNetwork network = new ActivationNetwork(new SigmoidFunction(2),2,2,1);
	// Use this for initialization
	void Start () {
		network.Randomize();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

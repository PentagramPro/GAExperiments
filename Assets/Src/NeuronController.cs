using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AForge.Neuro;

public class NeuronController : MonoBehaviour {
	public List<SensorController> Sensors;
	public List<ActuatorController> Actuators;
	ActivationNetwork network = null;
	// Use this for initialization
	void Start () {
		network = new ActivationNetwork(new SigmoidFunction(2), Sensors.Count, Actuators.Count, 1);
		network.Randomize();
		
	}

	// Update is called once per frame
	void FixedUpdate() {
		double[] sensors = Sensors.ConvertAll<double>((s) => { return s.Signal; }).ToArray();
		network.Compute(sensors);
		int i = 0;
		foreach(var a in Actuators)
		{
			a.SetForce((float)network.Output[i]);
			i++;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AForge.Neuro;
using AForge.Genetic;

public class NeuronController : MonoBehaviour {
	public List<SensorController> Sensors;
	public List<ActuatorController> Actuators;
	ActivationNetwork network = null;
	public IChromosome LinkedChromosome { get; private set; }
	public float Rating { get; private set; }

	public int GenomSize { get; private set; }
	// Use this for initialization
	void InitNetwork (double[] data) {
		network = CreateNetwork();
		network.Randomize();
		GenomSize = CalculateNetworkSize(network);
	}

	public int PrefabGetGenomeSize()
	{
		var testNetwork = CreateNetwork();
		return CalculateNetworkSize(testNetwork);
	}
	ActivationNetwork CreateNetwork()
	{
		return new ActivationNetwork(new SigmoidFunction(2), Sensors.Count, Actuators.Count, Actuators.Count);
	}

	int CalculateNetworkSize(ActivationNetwork net)
	{
		int size = 0;
		foreach (var l in net.Layers)
		{
			foreach (var n in l.Neurons)
			{
				size += n.Weights.Length;
			}
		}
		return size;
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

	public NeuronController PrefabInstantiate(double[] data, IChromosome link,Transform parent)
	{
		var result = Instantiate(this);
		result.LinkedChromosome = link;
		result.InitNetwork(data);
		result.transform.SetParent(parent);
		return result;
	}
}

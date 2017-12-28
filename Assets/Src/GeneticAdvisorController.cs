using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AForge.Genetic;
using AForge.Math.Random;

public class GeneticAdvisorController : MonoBehaviour {
	class NeuronFitnessFunction : IFitnessFunction
	{
		private Dictionary<IChromosome, double> ratings;
		public NeuronFitnessFunction(Dictionary<IChromosome, double> ratings)
		{
			this.ratings = ratings;
		}
		public double Evaluate(IChromosome chromosome)
		{
			return ratings[chromosome];
		}
	}

	public ArenaController Arena;
	public NeuronController AnimalPrefab;
	public Dictionary<IChromosome, double> ratings = new Dictionary<IChromosome, double>();

	public float GenerationLifetime = 15;
	float timeCounter = 0;
	Population population;

	// Use this for initialization
	void Start () {

		population = new Population(20,
		new DoubleArrayChromosome(new StandardGenerator(), new StandardGenerator(), new StandardGenerator(), AnimalPrefab.PrefabGetGenomeSize()),
		new NeuronFitnessFunction(ratings), new EliteSelection());

		Arena.StartSimulation(population);
	}

	// Update is called once per frame
	void Update () {
		timeCounter += Time.smoothDeltaTime;
		if(timeCounter>GenerationLifetime)
		{
			timeCounter = 0;
			NextGeneration();
		}
	}

	void NextGeneration()
	{
		Arena.StopSimulation();

		Arena.StartSimulation();
	}
}

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

	public AnimalController AnimalPrefab;
	public Dictionary<IChromosome, double> ratings = new Dictionary<IChromosome, double>();

	Population population;

	// Use this for initialization
	void Start () {
		population = new Population(20,
		new DoubleArrayChromosome(new StandardGenerator(), new StandardGenerator(), new StandardGenerator(), 10),
		new NeuronFitnessFunction(ratings), new EliteSelection());

	}

	// Update is called once per frame
	void Update () {
		
	}
}

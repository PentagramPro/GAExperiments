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
            
            if(!ratings.ContainsKey(chromosome))
            {
                return 0;
            }
            Debug.Log(string.Format("Evaluate for {0}", chromosome.GetHashCode()));
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
        Debug.Log("Creating population");
        population = new Population(20,
		new DoubleArrayChromosome(new StandardGenerator(), new StandardGenerator(), new StandardGenerator(), AnimalPrefab.PrefabGetGenomeSize()),
		new NeuronFitnessFunction(ratings), new EliteSelection());

        Debug.Log("Starting simulation");
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
        Debug.Log("Stopping simulation");
		Arena.StopSimulation(ratings);

        // hack
        population.FitnessFunction = new NeuronFitnessFunction(ratings);

        population.RunEpoch();

        Debug.Log("Starting another simulation");
        Arena.StartSimulation(population);
	}
}

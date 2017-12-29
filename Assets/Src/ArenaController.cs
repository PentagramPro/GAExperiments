using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AForge.Genetic;

public class ArenaController : MonoBehaviour {

	public Vector3 SpawnArea = new Vector3(1,1);
	public NeuronController AnimalPrefab;
    public SensorTargetController FoodPrefab;
    public int FoodCount = 15;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine(transform.position - SpawnArea, transform.position + new Vector3(SpawnArea.x, -SpawnArea.y));
		Gizmos.DrawLine(transform.position + SpawnArea, transform.position + new Vector3(-SpawnArea.x, SpawnArea.y));

	}

	public void StartSimulation(Population population)
	{
		for(int i=0;i<population.Size;i++)
		{
			DoubleArrayChromosome c = population[i] as DoubleArrayChromosome;
			if(c==null)
			{
				Debug.LogError("IChromosome with wrong type");
				continue;
			}

			var animal = AnimalPrefab.PrefabInstantiate(c.Value, c, transform);
			animal.transform.localPosition = GetRandomPosition();
		}
        for(int i=0;i<FoodCount;i++)
        {
            var food = Instantiate(FoodPrefab,transform);
            food.transform.localPosition = GetRandomPosition();
        }
	}

	public void StopSimulation(Dictionary<IChromosome, double> ratings)
	{
        ratings.Clear();

        var animals = GetComponentsInChildren<NeuronController>();
        foreach(var animal in animals)
        {
            ratings.Add(animal.LinkedChromosome, animal.Rating);
        }

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

	Vector3 GetRandomPosition()
	{
		float x = Random.Range(-SpawnArea.x, SpawnArea.x);
		float y = Random.Range(-SpawnArea.y, SpawnArea.y);
		return new Vector3(x, y);
	}
}

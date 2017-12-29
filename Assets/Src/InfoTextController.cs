using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTextController : MonoBehaviour {

    public GeneticAdvisorController GA;
    Text t;
	// Use this for initialization
	void Start () {
        t = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        string str = "";

        str += string.Format("Fitness max: {0}, Fitness avg: {1}", GA.LastFitnessMax,GA.LastFitnessAvg);
        
        t.text = str;
	}
}

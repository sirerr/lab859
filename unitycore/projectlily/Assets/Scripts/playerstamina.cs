using UnityEngine;
using System.Collections;

public class playerstamina : MonoBehaviour {
	//total energy
	public float playerenergy = 0;
	//dec amount
	public float playerusage = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void decreaseenergy()
	{
		playerenergy -= playerusage;

	}
}

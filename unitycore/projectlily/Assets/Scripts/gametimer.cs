using UnityEngine;
using System.Collections;

public class gametimer : MonoBehaviour {

	//counter for counting up
	public float timercounterup = 0;
	//timerup limit
	public float timeruplimit = 0;
	// count down
	public float timercounterdown = 0;
	//chosen difficulty
	public int chosendiff = 0;

	//easy difficulty
	public float easytime = 0;
	//medium difficulty
	public float medtime =0;
	//hard difficulty
	public float hardtime =0;


	// Use this for initialization
	void Start () {

	
		switch (chosendiff)
		{
		case 0:
			//diffculty is easy 900 seconds
			timercounterdown = easytime;
			break;
		case 1:
			//difficulty is medium
			timercounterdown = medtime;
			break;
		case 2:
			//difficulty is hard
			timercounterdown = hardtime;
			break;
		}

		timeruplimit = timercounterdown;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timerref : MonoBehaviour {
	//referencing game controller timer
	public gametimer gametimerref;
	//
	public Text timetext;

	// Use this for initialization
	void Start () {
		gametimerref = GameObject.FindWithTag("GameController").GetComponent<gametimer>();

		timetext = GetComponent<Text>();
		//print (gametimerref.timemins);
		timetext.text = gametimerref.timemins.ToString("f0")+":00";
	}
	
	// Update is called once per frame
	void Update () {
	
					if(gametimerref.timesecs<10&&gametimerref.timesecs>=0)
					{
						timetext.text = gametimerref.timemins.ToString("f0") +":0"+gametimerref.timesecs;
					}
					else
					{
						timetext.text = gametimerref.timemins.ToString("f0") +":"+gametimerref.timesecs;
					}


	}


}

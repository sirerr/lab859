using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gametimer : MonoBehaviour {

	//counter for counting up
	public float timercounterup = 0;
	//timerup limit
	public float timeruplimit = 0;
	// count down
	public float timercounterdown = 0;
	//minutes and hours
	public float timemins =0;
	public float timesecs =0;

	//chosen difficulty
	public int chosendiff = 0;
	//holding off timer
	public bool timerhold = false;
	//timer game object
//	public Text timertext;

	//easy difficulty
	public float easytime = 0;
	//medium difficulty
	public float medtime =0;
	//hard difficulty
	public float hardtime =0;


	// Use this for initialization
	void Awake () {

	//	timertext = transform.GetComponent<Text>();
	
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

		timemins =  Mathf.Abs(timercounterdown/60f);
	//	timertext.text = timemins.ToString("f0")+":00";

	}

	void Start()
	{
		StartCoroutine(goingup());
	}

	IEnumerator goingup()
	{
		if(!timerhold)
		{

			timercounterdown-=1f;
			timercounterup+=1f;
	
			if(timesecs == 0f)
			{
				timemins-=1;
				timesecs = 59f;
			}else
			{
				timesecs-=1;
			}

			yield return new WaitForSeconds(1f);

//			if(timesecs<10&&timesecs>=0)
//			{
//				timertext.text = timemins.ToString("f0") +":0"+timesecs;
//			}
//			else
//			{
//				timertext.text = timemins.ToString("f0") +":"+timesecs;
//			}
		}
		quickloop();

	}

public void quickloop()
	{
		StartCoroutine(goingup());
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}

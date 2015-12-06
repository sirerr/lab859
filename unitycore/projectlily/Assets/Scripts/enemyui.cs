using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enemyui : MonoBehaviour {
	//parented ui canvas
	public GameObject ecanvas;

	//repeat rate for invoke
	public float repeatfuncrate =0;
	//repeat time
	public float repeattime=0;

	//bool value for being looked at
	public bool lookedat = false;

	//find player
	public GameObject playerobj;

	//stamina ref
	public playerstamina playerstaminaref;

	//button 1
	public Button button1;
	//button 2
	public Button button2;
	//button 3
	public Button button3;

	//value to increase stamina
	public int incstaminavalue =0;

	void Awake()
	{


	}

	// Use this for initialization
	void Start () {

		playerstaminaref = GameObject.Find("gameman").GetComponent<playerstamina>();
		playerobj = playerstaminaref.playerobj;

		ecanvas = transform.GetChild(0).gameObject;

		button1 = ecanvas.transform.GetChild(0).GetComponent<Button>();
		button2 = ecanvas.transform.GetChild(1).GetComponent<Button>();
		button3 = ecanvas.transform.GetChild(2).GetComponent<Button>();
	
		button1.onClick.AddListener(()=>{choiceone();});
		button2.onClick.AddListener(()=>{choicetwo();});
		button3.onClick.AddListener(()=>{choicethree();});
	}
	
	// Update is called once per frame
	void Update () {
	
		ecanvas.transform.LookAt(playerobj.transform.position);
	//	ecanvas.transform = Vector3.forward;
	}

	public void disablecanvas()
	{
		if(lookedat){
		lookedat = false;		
		ecanvas.SetActive(false);
		}
	}

	public void enablecanvas()
	{
	//	print ("sending message");
		ecanvas.SetActive(true);

		//Invoke("disablecanvas",repeattime);
		lookedat = true;
	}

	public void choiceone()
	{

		if((playerstaminaref.playerenergy - playerstaminaref.useflash)>=0)
		{
			StopCoroutine(incstamina());
			playerobj.GetComponent<Playercontrol>().flash();
			playerstaminaref.flashattack();
			StartCoroutine(incstamina());
		}


	}

	public void choicetwo()
	{
		if((playerstaminaref.playerenergy - playerstaminaref.usefire)>=0)
		{

			StopCoroutine(incstamina());
			playerobj.GetComponent<Playercontrol>().fire();
			playerstaminaref.fireattack();
			StartCoroutine(incstamina());
		}
	}

	public void choicethree()
	{
		if((playerstaminaref.playerenergy - playerstaminaref.useboom)>=0)
		{
			StopCoroutine(incstamina());
		playerobj.GetComponent<Playercontrol>().bigboom();
			playerstaminaref.boomattack();
			StartCoroutine(incstamina());
		}
	}

	IEnumerator incstamina()
	{
		for(int i =0;i<=incstaminavalue;i++)
		{
			if(playerstaminaref.playerenergy<playerstaminaref.tempenergy)
			{
				yield return new WaitForSeconds(1f);
				playerstaminaref.playerenergy++;

			}
		}

	}

}

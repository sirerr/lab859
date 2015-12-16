using UnityEngine;
using System.Collections;

public class interactobject : MonoBehaviour {

	//has it been used yet
	public bool usedyet = false;
	//ref to player stamina to get player object
	public playerstamina playerstaminaref;
	//player obj
	public GameObject playerobj;
	// amount of time for corotine in order to do animation for player
	public float corotinetime =0;

	public void playerinteract()
	{
		if(!usedyet)
		{
			usedyet = true;
			playerobj.GetComponent<Playercontrol>().enabled = false;
			// do the animation, disable the player control script then enable in a corotine
			StartCoroutine(reenableplayerstatesystem());
		}

	}

	 void Awake()
	{
		playerstaminaref = GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<playerstamina>();


	}

	IEnumerator reenableplayerstatesystem()
	{
		print ("entering wait time");
		yield return new WaitForSeconds(corotinetime);
		print("entering exit time");
		playerobj.GetComponent<Playercontrol>().enabled = true;
	}


	// Use this for initialization
	void Start () {
		playerobj = playerstaminaref.playerobj;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

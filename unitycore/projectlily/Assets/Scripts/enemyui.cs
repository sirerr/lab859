using UnityEngine;
using System.Collections;

public class enemyui : MonoBehaviour {
	//parented ui canvas
	public GameObject ecanvas;

	//repeat rate for invoke
	public float repeatfuncrate =0;
	//repeat time
	public float repeattime=0;

	//bool value for being looked at
	public bool lookedat = false;

	// Use this for initialization
	void Start () {

		ecanvas = transform.GetChild(0).gameObject;
	
	}
	
	// Update is called once per frame
	void Update () {
	
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


}

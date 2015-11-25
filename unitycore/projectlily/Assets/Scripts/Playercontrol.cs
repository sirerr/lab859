using UnityEngine;
using System.Collections;

public class Playercontrol : MonoBehaviour {
	//player transform
	public Transform playertrans;
	//bool for input
	public bool usermoveinput = false;
	//bool for backbutton
	public bool userbackbutton = false;
	//user speed
	public float playerspeed = 0f;
	//backupspeed
	public float backupplayerspeed =0f;
	// center anchor game object
	public GameObject centeranchor;
	// Use this for initialization

	// state machine for input
	//10 is walking around
	//20 is picking stuff up
	//30 is attack
	public int playerstate =100;

	//object being raycasted distance
	public float objectdistance =0;

	//raycast distance
	public float raycastdistance =0;
	//interact layer mask
	public LayerMask interactlayer = 1<<8;


	void Start () {
		playertrans = transform;

		if(Application.platform ==RuntimePlatform.WindowsEditor)
		{
			centeranchor.transform.GetComponent<MouseLook>().enabled = true;
		}

	}
	
	// Update is called once per frame
	void Update () {

		//raycast info
		Vector3 forwardlook = centeranchor.transform.forward;
		RaycastHit playerlook;

		usermoveinput = Input.GetMouseButton (0);
		userbackbutton = Input.GetMouseButton(1);

		Debug.DrawRay(centeranchor.transform.position,forwardlook * raycastdistance, Color.red, .1f);

		Physics.Raycast(centeranchor.transform.position,forwardlook *raycastdistance, out playerlook,interactlayer);

		//print (forwardlook);

		if (playerlook.collider == null) 
		{
			playerstate =10;
			return;
		} 

		if (playerlook.transform.tag == "collect") {
			playerstate = 20;
		} else if (playerlook.transform.tag == "enemy") {
			playerstate = 30;
		} else 
		{
			playerstate =10;
		}

	
		objectdistance = Vector3.Distance(playerlook.transform.position,transform.position);

		switch (playerstate)
		{
		case 100:
			//default state, nothing will happen
		break;
		case 10:
			if (usermoveinput) {
				Vector3 move = forwardlook * playerspeed * Time.deltaTime;
			//	Debug.Log(transform.position);
			//	Debug.Log(move);

				//transform.Translate(move.x, move.y, move.z);
				transform.position += move;
			//	Debug.Log(transform.position);
			}
		break;
		//looking at collectable
		case 20:
			print ("looking at collectable");
			if(usermoveinput && objectdistance>2)
			{
				//start hand animation and stop clock
			}
		break;
		//looking at enemy
		case 30:
			print ("looking at enemy");
			if (usermoveinput) {
				
				transform.Translate(Vector3.forward *-1 * playerspeed* Time.deltaTime,Space.Self);
			}
		break;
		//this will be the state of transitions
		case 40:

		break;
		}

	}
}





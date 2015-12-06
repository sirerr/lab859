using UnityEngine;
using System.Collections;

public class playerstamina : MonoBehaviour {
	//total energy
	public float playerenergy = 0;

	//dec amount for flash
	public float useflash = 0;
	// dec amount for fire
	public float usefire =0;
	// dec amount for boom
	public float useboom =0;

	// player ref
	public GameObject playerobj;

	// stamina bars in scene
	public GameObject[] staminabars;

	// temp value of stamina
	public float tempenergy =0;

	//full stamina color
	public Color fullstaminacolor;

	//no stamina color
	public Color nostaminacolor;

	//current color
	public Material currentstaminacolor;

	void Awake()
	{
		playerobj = GameObject.FindGameObjectWithTag("Player");
		staminabars = GameObject.FindGameObjectsWithTag("stabars");

		tempenergy = playerenergy;
	//	currentstaminacolor.color = fullstaminacolor;
	}

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
	
	//	print (playerenergy);


	}



	public void flashattack()
	{

		playerenergy -= useflash;
		for(int i=0; i<staminabars.Length;i++)
		{
			print(playerenergy);
			staminabars[i].GetComponent<MeshRenderer>().material.color = Color.Lerp(nostaminacolor,fullstaminacolor,(playerenergy/100f));

		}
	//	currentstaminacolor.color = staminabars[0].GetComponent<MeshRenderer>().material.color;
	}

	public void fireattack()
	{
		playerenergy -= usefire;
		for(int i=0; i<staminabars.Length;i++)
		{
			print(playerenergy);
			staminabars[i].GetComponent<MeshRenderer>().material.color = Color.Lerp(nostaminacolor,fullstaminacolor,(playerenergy/100f));
			
		}

	}

	public void boomattack()
	{
		playerenergy -= useboom;

		for(int i=0; i<staminabars.Length;i++)
		{
			print(playerenergy);
			staminabars[i].GetComponent<MeshRenderer>().material.color = Color.Lerp(nostaminacolor,fullstaminacolor,(playerenergy/100f));
			
		}
	}


}

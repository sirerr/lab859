using UnityEngine;
using System.Collections;

public class cursoraction : MonoBehaviour {

	public Camera cameraobj;
	private Vector3 originalscale;

	// Use this for initialization
	void Start () {
		originalscale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
	
		RaycastHit hit;
		float distance;

		if(Physics.Raycast (new Ray (cameraobj.transform.position,
			cameraobj.transform.rotation * Vector3.forward),
			out hit))
			{
				distance = hit.distance;
			}
		else
		{
			distance = cameraobj.farClipPlane * 0.99f;
		}
		transform.position = cameraobj.transform.position + cameraobj.transform.rotation *Vector3.forward * 
			distance;
		transform.LookAt(cameraobj.transform.position);
		transform.Rotate(0,180f,0);
		if(distance<10f)
		{
			distance *= 1+5*Mathf.Exp(-distance);
		}
		transform.localScale= originalscale * distance;
	
	}
}

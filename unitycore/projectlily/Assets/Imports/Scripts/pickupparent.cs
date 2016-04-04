using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class pickupparent : MonoBehaviour {

	SteamVR_TrackedObject trackedobj;
	SteamVR_Controller.Device device;

	public Transform sphere;

	void Awake () {
		trackedobj = GetComponent<SteamVR_TrackedObject>();
	}
	

	void FixedUpdate () {
		device = SteamVR_Controller.Input((int)trackedobj.index);
		if(device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
		{
			Debug.Log("you are holding 'Touch' the trigger");
		}

		if(device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
		{
			Debug.Log("you have activated 'touchdown' the trigger");
		}

		if(device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
		{
			Debug.Log("you have activated 'touchdown' the trigger");
		}

		if(device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
		{
			Debug.Log("you are holding 'Touch' the trigger");
		}

		if(device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
		{
			Debug.Log("you have activated 'touchdown' the trigger");
		}

		if(device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
		{
			Debug.Log("you have activated 'touchdown' the trigger");
		}

		if(device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
		{
			Debug.Log("you have activated 'pressdown' the touchpad");
			sphere.transform.position = new Vector3(0,0,0);
			sphere.GetComponent<Rigidbody>().velocity  = Vector3.zero;
			sphere.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		}
	}

	void OnTriggerStay(Collider col)
	{
		Debug.Log("you have collided with "+ col.name + " and activated Ontriggerstay");

		if(device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
		{
			Debug.Log("you have collided with col.name");
			col.attachedRigidbody.isKinematic = true;
			col.gameObject.transform.SetParent(gameObject.transform);
		}
		if(device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
		{
			Debug.Log("you have released touch while colliding with the collider");
			col.gameObject.transform.SetParent(null);
			col.attachedRigidbody.isKinematic = false;
	
			tossobject(col.attachedRigidbody);
		}


	}
	void tossobject(Rigidbody rigidbody)
	{
		Transform origin = trackedobj.origin ? trackedobj.origin : trackedobj.transform.parent;
		if(origin!=null)
		{
			rigidbody.velocity = origin.TransformVector(device.velocity);
			rigidbody.angularVelocity = origin.TransformVector(device.angularVelocity);
		}else
		{
			rigidbody.velocity = device.velocity;
			rigidbody.angularVelocity = device.angularVelocity;	
		}

	}
}

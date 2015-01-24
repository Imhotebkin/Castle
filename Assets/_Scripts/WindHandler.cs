using UnityEngine;
using System.Collections;

public class WindHandler : MonoBehaviour 
{
	private GameObject target;
	private float forceToApply;
	private Quaternion q;
	private Vector3 VVV;
	private float f;

	void Awake () 
	{
		target = GameObject.FindGameObjectWithTag ("Wind");
		forceToApply = target.GetComponent<WindSim> ().force;
		q = target.transform.rotation;
		VVV = q.eulerAngles;
		VVV.y = 0;
	}

	void Update()
	{
		constantForce.force = VVV * forceToApply;
	}
}

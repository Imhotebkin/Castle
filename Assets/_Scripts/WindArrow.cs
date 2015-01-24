using UnityEngine;
using System.Collections;

public class WindArrow : MonoBehaviour 
{
	private GameObject target;
	private Vector3 VVV;
	private Quaternion q;


	void Awake () 
	{
		target = GameObject.FindGameObjectWithTag ("Wind");
		q = target.transform.rotation;
		VVV = q.eulerAngles;
		VVV.y = 0;
		q = Quaternion.LookRotation (VVV);
		q.z = 0;
		q.y = 0;
	}

	void Update () 
	{
		transform.rotation =q;
	}
}

using UnityEngine;
using System.Collections;

public class Landing : MonoBehaviour 
{
	private Rigidbody ToDest;

	void Awake()
	{
		ToDest = GetComponentInParent<Rigidbody> ();
	}
	void OnTriggerEnter ()
	{
		Destroy (ToDest);
	}
}

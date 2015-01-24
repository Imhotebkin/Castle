using UnityEngine;
using System.Collections;

public class WindSim : MonoBehaviour 
{
	public float rotor;
	public float force;

	void Start () 
	{
		Rotate ();
	}
	
	public void Rotate()
	{
		force = Random.Range(0,10);
		rotor = Random.Range(0,359);
		transform.Rotate (rotor, 0, rotor);
	}
}

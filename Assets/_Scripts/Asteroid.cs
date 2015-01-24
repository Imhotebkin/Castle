using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour 
{
	public float Tumble;

	void Start()
	{
		rigidbody.angularVelocity = Random.insideUnitSphere * Tumble;
	}
}

using UnityEngine;
using System.Collections;

public class DestTime : MonoBehaviour 
{
	public float lifetime;

	void Start()
	{
		Destroy (gameObject, lifetime);
	}
}

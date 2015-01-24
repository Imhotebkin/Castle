using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour 
{
	public float speed;
	public int damage;
	public GameObject Expl;
	private GameObject Parent;

	void Start()
	{
		rigidbody.velocity = transform.forward * speed;
	}

	void shotSpeed(float a)
	{
		speed = a;
	}

	void OnTriggerEnter(Collider a)
	{
		Destroy (gameObject);
		Instantiate (Expl, transform.position, transform.rotation);
		if (a.gameObject.tag == "Pl1")
		{
			Parent = GameObject.Find("Player1");
			Parent.SendMessage("Damage",damage);
		} 
		if (a.gameObject.tag == "Pl2")
		{
			Parent = GameObject.Find("Player2");
			Parent.SendMessage("Damage",damage);
		} 
	}
}

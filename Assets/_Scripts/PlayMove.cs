using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayMove : MonoBehaviour 
{
	public float speed, tilt;
	public Text countText;
	public Text LossText;
	public Transform ShotSpawn;
	public GameObject shot;
	public float firerate;

	private int count;
	public Boundary boundary;
	private float nextFire;

	//movement
	void FixedUpdate()
	{
		float movehorizontal = Input.GetAxis("Horizontal");
		float movevertival = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3 (movehorizontal, 0.0f, movevertival);
		rigidbody.velocity = movement*speed;
	
		rigidbody.position = new Vector3 
			(
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
			);
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}

	//shooting
	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		    {
			nextFire=Time.time+firerate;
			Instantiate (shot, ShotSpawn.position, ShotSpawn.rotation);
			audio.Play();
			}
	}
}

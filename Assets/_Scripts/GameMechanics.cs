using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameMechanics : MonoBehaviour 
{
	private GameObject pl1;
	private GameObject pl2;
	private GameObject pl1turret;
	private GameObject pl2turret;
	private GameObject pl1Cam;
	private GameObject pl2Cam;

	private bool pl1turn = true;



	void Awake() 
	{
		pl1 = GameObject.FindGameObjectWithTag ("Pl1"); 
		pl2 = GameObject.FindGameObjectWithTag ("Pl2");
		pl1Cam = getChildGameObject(pl1,"Camera");
		pl2Cam = getChildGameObject(pl2,"Camera");
		pl1turret = getChildGameObject(pl1,"Head");
		pl2turret = getChildGameObject(pl2,"Head");
	}

	GameObject getChildGameObject(GameObject fromGameObject, string withName) 
	{
		Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform> (true);
		foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
		return null;
	}
	
	public void PlTurn () 
	{
		if (pl1turn == true)
		{
			pl1Cam.SetActive (true);
			pl1turret.SetActive (true);
			pl2Cam.SetActive (false);
			pl2turret.SetActive (false);
			pl1turn = false;
		} 
		else 
		{
			pl2Cam.SetActive (true);
			pl2turret.SetActive (true);
			pl1Cam.SetActive (false);
			pl1turret.SetActive (false);
			pl1turn = true;
		}
	}
}

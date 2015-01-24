using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadLevel1 : MonoBehaviour 
{
	public GameObject L1;
	public GameObject L2;
	public GameObject GameHandler;
	private GameObject Namer;

	void LoadLevelOne()
	{
		Namer = (GameObject) Instantiate (L1);
		Namer = (GameObject) Instantiate (GameHandler);
		Namer.SendMessage ("PlTurn");
	}

	void LoadLevelTwo()
	{
		Namer = (GameObject) Instantiate (L2);
		Namer = (GameObject) Instantiate (GameHandler);
		Namer.SendMessage ("PlTurn");
	}
}

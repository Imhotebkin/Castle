using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class MyOwnGenerator : MonoBehaviour 
{
	public GameObject Player;
	public Object GameHandler;
	public Transform origin;
	public Object terrainPlane;
	public float Proundness = 0.1f;
	public float Pheight = 10f;
	public float PSize = 200f;
	public InputField ScaleField;
	public InputField RoundField;
	public InputField HeightField;

	private float x,z;
	private Vector3 VVV;
	private Quaternion q;
	private GameObject Namer;

	void Start()
	{
		BeginGeneration ();
	}

	void BeginGeneration()
	{
		if (RoundField.text.Length>0)
		Proundness = float.Parse(RoundField.text);
		if (HeightField.text.Length>0)
		Pheight = float.Parse(HeightField.text);
		if (ScaleField.text.Length>0)
		PSize = float.Parse(ScaleField.text);
		GameObject plane =(GameObject)Instantiate(terrainPlane, new Vector3(0, 1, 0), Quaternion.identity);
		plane.transform.localScale = new Vector3(PSize * 0.1f, 1, PSize * 0.1f);
		plane.transform.parent = origin;
		plane.tag = "Plane";
		Mesh mesh = plane.GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		for (int v = 0; v < vertices.Length; v++) 
		{
			Vector3 vertexPosition = plane.transform.position + vertices[v] * PSize / 10f;
			float height = SimplexNoise.Noise(vertexPosition.x * Proundness, vertexPosition.z * Proundness);
			vertices[v].y = height * Pheight + height;
		}
		mesh.vertices = vertices;
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
		plane.AddComponent<MeshCollider>();

		q.Set (0, 0, 0, 0);
		x = Random.Range (0, PSize/2);
		z = Random.Range (0, PSize/2);
		VVV.Set(x,Pheight,z);
		Namer = (GameObject)Instantiate (Player, VVV, q);
		Namer.name = "Player1";
		Namer.tag = "Pl1";
		Namer.SendMessage("FindSlider","P1HP");
		x = Random.Range (-PSize/2,0);
		z = Random.Range (-PSize/2,0);
		VVV.Set(x,Pheight,z);
		Namer =(GameObject) Instantiate (Player, VVV, q);
		Namer.name = "Player2";
		Namer.tag = "Pl2";
		Namer.SendMessage("FindSlider","P2HP");
		Namer = (GameObject) Instantiate (GameHandler);
		Namer.SendMessage ("PlTurn");
	}
}

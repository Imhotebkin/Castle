using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Submit : MonoBehaviour 
{
	public InputField ScaleField;
	public InputField RoundField;
	public InputField HeightField;
	public GameObject generator;
	public float[] t;

	void Textting()
	{
		t[0] = float.Parse(ScaleField.text);
		t[1] = float.Parse(RoundField.text);
		t[2] = float.Parse(HeightField.text);
	}
}

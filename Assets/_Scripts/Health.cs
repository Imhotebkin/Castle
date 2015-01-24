using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour
{
	public int MaxHealth = 100;
	private Slider HealthSl;
	private GameObject SliderHolder;

	void FindSlider(string s)
	{
		SliderHolder = GameObject.Find (s);
		HealthSl = SliderHolder.GetComponent<Slider> ();
		HealthSl.maxValue = MaxHealth;
		HealthSl.value = MaxHealth;
	}

	void Damage(int damage)
	{
		HealthSl.value -= damage;
		if (HealthSl.value <= 0) 
		{
			GameObject.Find("DED").GetComponent<Text>().text=transform.name+" is dead";
			Time.timeScale=0;
		}
	}
}

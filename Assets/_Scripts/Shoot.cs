using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shoot : MonoBehaviour 
{
	public Transform ShotSpawn;
	public GameObject[] shots;
	public float maxPower=100f;
	public float minPower;
	public float launchPower;
	public Slider PowerSlider;

	private GameObject TextHolder;
	private Text weapText;
	private GameObject SliderHolder;
	private GameObject Game;
	private bool alreadyShot=false;
	private int activeWeap=0;
	private float timer;
	private bool GoingUp;
	private GameObject shot;

	void Awake()
	{
		SliderHolder = GameObject.Find ("Slider");
		PowerSlider = SliderHolder.GetComponent<Slider>();
		PowerSlider.maxValue = maxPower;
		PowerSlider.minValue = minPower;
		TextHolder = GameObject.Find ("Weapon");
		weapText = TextHolder.GetComponent<Text>();
	}
	void Update () 
	{ 
		timer += Time.deltaTime;
		if (Input.GetButton ("Fire1") && alreadyShot == false)
		{
			if (GoingUp)
			{
				launchPower += 1;
				PowerSlider.value = launchPower;
				if (launchPower > maxPower)
				{
					GoingUp = false;
				}
			}
			else
			{
				launchPower -= 1;
				PowerSlider.value = launchPower;
				if (launchPower < minPower)
				{
					GoingUp = true;
				}
			}
		}
		if (Input.GetButtonUp ("Fire1") && alreadyShot == false)
		{
			Game =GameObject.FindGameObjectWithTag ("GameController");
			shot =(GameObject)Instantiate (shots[activeWeap], ShotSpawn.position, ShotSpawn.rotation);
			shot.SendMessage("shotSpeed",launchPower);
			alreadyShot=true;
			StartCoroutine (finish());
		}
		if (Input.GetButtonUp ("Fire2")&& alreadyShot == false)
		{
			if (activeWeap==0)
			{
				activeWeap=1;
				weapText.text="Asteroid Shot";
			}
			else
			{
				activeWeap=0;
				weapText.text="Light Shot";
			}
		}
	}

	IEnumerator finish()
	{
		yield return new WaitForSeconds(5);
		alreadyShot = false;
		Game.SendMessage("PlTurn");
	}
}

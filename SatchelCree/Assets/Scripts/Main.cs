using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	//All Phantoms
	[SerializeField]
	public List<Phantom> allPhantoms;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}

[System.Serializable]
public class Phantom
{
	
	public Type type;

	public string name;
	public string nickName;

	public float baseHealth;
	public float currentHealth;

	public float basePower;
	public float currentPower;

	public float baseDefense;
	public float currentDefense;

	public float baseAgility;
	public float currentAgility;

}

public enum Type
{
	earth,
	wind,
	fire,
	water
}
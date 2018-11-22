using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	//All Phantoms
	[SerializeField]
	public List<Phantom> allPhantoms;

	Phantom enemyMonster;
	Phantom usedMonster;

	// Use this for initialization
	void Start ()
	{
		enemyMonster = allPhantoms[0];
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnGUI()
	{
		Player playerCharacter;
		playerCharacter = GameObject.Find("PlayerCharacter").GetComponent<Player>();

		//display monster in combat
		if(playerCharacter.isInCombat)
		{
			GUI.Label(new Rect(50, 100, 200, 100), "" + enemyMonster.GetName());
			GUI.DrawTexture(new Rect(70, 100, 128, 128), enemyMonster.image);
		}
	}
}






[System.Serializable]
public class Phantom
{
	
	public Type type;
	public Rarity rarity;
	public Texture image;

	public string regionLocated;

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

	public string GetName()
	{
		if(nickName != "")
		{
			return nickName;
		}
		return name;
	}

}

public enum Type
{
	Earth,
	Wind,
	Fire,
	Water
}

public enum Rarity
{
	Common,
	Uncommon,
	Rare,
	UltraRare,
	Legendary
}
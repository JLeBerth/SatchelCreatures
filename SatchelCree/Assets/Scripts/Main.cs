using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	//All Phantoms
	[SerializeField]
	public List<Phantom> allPhantoms;

	[SerializeField]
	public List<Ability> allAbilities;

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
			GUI.Label(new Rect(50, 110, 200, 100), "" + enemyMonster.GetName());
			GUI.DrawTexture(new Rect(70, 150, 128, 128), enemyMonster.image);
		}
	}
}


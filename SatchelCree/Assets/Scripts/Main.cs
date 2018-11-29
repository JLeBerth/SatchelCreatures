using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    enum CombatState { chooseMove, resolveMoves, checkStatus}
    CombatState combatState;
    public Player player;
	//All Phantoms
	[SerializeField]
	public List<Phantom> allPhantoms;

	[SerializeField]
	public List<Ability> allAbilities;

	Phantom enemyMonster;
	Phantom usedMonster;
    Ability usedAbility;
    Ability enemyAbility;

	// Use this for initialization
	void Start ()
	{
        combatState = CombatState.chooseMove;
		enemyMonster = allPhantoms[0];
        usedMonster = allPhantoms[1];

        enemyMonster.level = 5;
        usedMonster.level = 5;

        enemyMonster.GetKnownMoves();
        usedMonster.GetKnownMoves();
        foreach(int thisMove in enemyMonster.knownAbilities)
        {
            enemyMonster.equippedAbilities.Add(allAbilities[thisMove]);
        }
        foreach (int thisMove in usedMonster.knownAbilities)
        {
            usedMonster.equippedAbilities.Add(allAbilities[thisMove]);
        }


    }
	
	// Update is called once per frame
	void Update ()
	{
        if (player.isInCombat)
        {
            switch (combatState)
            {
                case CombatState.chooseMove:
                    if (Input.GetKeyDown("0"))
                    {
                        usedAbility = usedMonster.equippedAbilities[0];
                        enemyAbility = enemyMonster.equippedAbilities[Random.Range(0, enemyMonster.equippedAbilities.Count - 1)];
                        combatState = CombatState.resolveMoves;
                    }
                    else if (Input.GetKeyDown("1"))
                    {
                        usedAbility = usedMonster.equippedAbilities[1];
                        enemyAbility = enemyMonster.equippedAbilities[Random.Range(0, enemyMonster.equippedAbilities.Count - 1)];
                        combatState = CombatState.resolveMoves;
                    }
                        break;

                case CombatState.resolveMoves:
                    if(usedMonster.currentAgility > enemyMonster.currentAgility)
                    {
                        ResolveMove(true, usedAbility);
                        if(enemyMonster.currentHealth <= 0)
                        {
                            combatState = CombatState.checkStatus;
                            break;
                        }
                        ResolveMove(false, enemyAbility);
                    }
                    else
                    {
                        ResolveMove(false, enemyAbility);
                        if(usedMonster.currentHealth <=0)
                        {
                            combatState = CombatState.checkStatus;
                            break;
                        }
                        ResolveMove(true, usedAbility);
                    }
                    combatState = CombatState.checkStatus;
                    break;

                case CombatState.checkStatus:
                    bool end = false;
                    if (usedMonster.currentHealth <= 0 && enemyMonster.currentHealth <= 0)
                    {
                        Debug.Log("Tie");
                        end = true;
                    }
                    else if(usedMonster.currentHealth <= 0)
                    {
                        Debug.Log("Lose");
                        end = true;
                    }
                    else if (enemyMonster.currentHealth <= 0)
                    {
                        Debug.Log("Win");
                        end = true;
                    }
                    combatState = CombatState.chooseMove;
                    if (end)
                    {
                        //player.isInCombat = false;
                    }
                    break;
            }
        }
	}

    public void ResolveMove(bool isUser, Ability used)
    {
        if (isUser)
        {
            if (usedMonster.currentStamina >= used.staminaCost)
            {
                int modifier;
                modifier = 1;
                usedMonster.currentStamina -= used.staminaCost;
                int damage = Mathf.RoundToInt(used.damage * (usedMonster.currentPower / enemyMonster.currentDefense) * modifier);
                enemyMonster.currentHealth -= damage;
                Debug.Log(usedMonster.GetName() + " Used: " + usedAbility.name + " And Dealt: " + damage + " damage");
            }
        }
        else
        {
            if (enemyMonster.currentStamina >= used.staminaCost)
            {
                int modifier;
                modifier = 1;
                enemyMonster.currentStamina -= used.staminaCost;
                int damage = Mathf.RoundToInt(used.damage * (usedMonster.currentPower / enemyMonster.currentDefense) * modifier);
                usedMonster.currentHealth -= damage;
                Debug.Log(enemyMonster.GetName() + " Used: " + enemyAbility.name + " And Dealt: " + damage + " damage");
            }
        }

    }
	void OnGUI()
	{
		Player playerCharacter;
		playerCharacter = GameObject.Find("PlayerCharacter").GetComponent<Player>();

		//display monster in combat
		if(playerCharacter.isInCombat)
		{
			GUI.Label(new Rect(1000, 50, 200, 100), "" + enemyMonster.GetName());
			GUI.Label(new Rect(72, 350, 200, 100), "" + usedMonster.GetName());

            GUI.Label(new Rect(1000, 60, 200, 100), "Health:");
            GUI.Label(new Rect(72, 360, 200, 100), "Health:");

            GUI.Label(new Rect(1000, 70, 200, 100), enemyMonster.currentHealth + "/" + enemyMonster.baseHealth);
            GUI.Label(new Rect(72, 370, 200, 100), usedMonster.currentHealth + "/" + usedMonster.baseHealth);

            GUI.Label(new Rect(1000, 80, 200, 100), "Stamina:");
            GUI.Label(new Rect(72, 380, 200, 100), "Stamina:");

            GUI.Label(new Rect(1000, 90, 200, 100), enemyMonster.currentStamina + "/" + enemyMonster.baseStamina);
            GUI.Label(new Rect(72, 390, 200, 100), usedMonster.currentStamina + "/" + usedMonster.baseStamina);

            GUI.DrawTexture(new Rect(872, 50, 128, 128), enemyMonster.image);
            GUI.DrawTexture(new Rect(200, 350, 128, 128), usedMonster.image);


        }
	}
}


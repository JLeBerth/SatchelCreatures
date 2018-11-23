using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Serializable Ability class, contains data for how an ability functions
/// </summary>
[System.Serializable]
public class Ability
{
	public string name;
	public Type moveType;
	public List<Effects> moveEffects;

	public float staminaCost;
	public float damage;
	public float accuracy;

}

/// <summary>
/// Effect class, lists the type of effect as well as what the effect targets, and its chance of occuring
/// </summary>
public class Effects
{
	public EffectTypes fxType;
	public Targets fxTarget;
	public float fxChance;
}

public enum EffectTypes
{
	buffSelf,
	debuffSelf,
	buffEnemy,
	debuffEnemy,
	destroySelf,
	destroyEnemy
}

public enum Targets
{
	none,
	Stamina,
	Power,
	Defense,
	Agility
}


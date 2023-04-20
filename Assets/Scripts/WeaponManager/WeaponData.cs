using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats
{
    public int damage;
    public float timeToAttack;
}

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string Name;
    public WeaponStats stats;
}

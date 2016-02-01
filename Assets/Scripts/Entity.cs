﻿using UnityEngine;
using System.Collections;

public class Entity : ScriptableObject {
    public string Name;
    public int Age;
    string Faction;
    public string Occupation;
    public int Level = 1;
    public int Health = 2;
    public int Strength = 1;
    public int Magic = 0;
    public int Defense = 0;
    public int Speed = 1;
    public int Damage = 1;
    public int Armor = 0;
    public int NoOfAttacks = 1;
    public string Weapon;
    public Vector2 Position;

    public void TakeDamage(int amount)
    {
        Health = Mathf.Clamp((amount - Armor), 0, int.MaxValue);
    }

    public void Attack(Entity entity)
    {
        entity.TakeDamage(Strength);
    }
}

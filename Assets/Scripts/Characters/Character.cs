using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IComparable<Character> {

    public CharacterStats stats;
    public List<Skill> skills;

    void Start()
    {
        stats.Reset();
    }

    [SerializeField]
    Character target;

    public void Attack(Character target)
    {
        this.target = target;
        Debug.Log(name + " attacked " + target.name +"!");

        Debug.Log(target.name + " went down to " + target.stats.TakeDamage(stats) + " health!");
    }



    public int CompareTo(Character other)
    {
        throw new NotImplementedException();
    }
}


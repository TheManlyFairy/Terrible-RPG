using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : Character, IComparable<Enemy>
{
    [SerializeField]
    int expValue;

    public int ExpValue { get { return expValue; } }

    public int CompareTo(Enemy other)
    {
        throw new NotImplementedException();
    }
}
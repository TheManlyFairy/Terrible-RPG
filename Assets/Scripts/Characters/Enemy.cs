using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : Character, IComparable<Enemy>
{
    public int CompareTo(Enemy other)
    {
        throw new NotImplementedException();
    }
}
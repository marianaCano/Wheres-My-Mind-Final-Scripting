﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motivacion : Personajes
{
    [SerializeField] private int type = 0;
    public int GetCharacterType()
    {
        return type;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distraccion : Personajes
{
    public int distractionType;

    public int GetCharacterType()
    {
        distractionType = Random.Range(1, 6);
        return distractionType;
    }
}

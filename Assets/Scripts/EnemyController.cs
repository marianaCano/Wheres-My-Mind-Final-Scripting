using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float debuffType;

    void Start()
    {
        debuffType = Random.Range(1, 6);
    }
}

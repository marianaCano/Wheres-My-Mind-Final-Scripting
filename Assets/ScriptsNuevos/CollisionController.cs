using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] protected casesSO channel;
    private Personajes perso_;

    void Start()
    {
        perso_ = GetComponent<Personajes>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        channel.characterFound(perso_);
    }
}

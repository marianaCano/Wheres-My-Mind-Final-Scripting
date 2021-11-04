using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
  
{
    public GameObject Player;
    private Vector3 Position;

    void Start()
    {
        Position = transform.position - Player.transform.position;
    }
    private void Update()
    {
        transform.position = Player.transform.position + Position;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class State : MonoBehaviour
{
    [SerializeField] GameObject paredDerecha, paredIzquierda, paredArriba, paredAbajo;
    public bool[] walls = new bool[4] { true, true, true, true };
    public bool visited = false;

    void Update()
    {
        if (walls[0] == false || paredDerecha.activeSelf == false)
        {
            paredDerecha.SetActive(false);
            walls[0] = false;
        }
        if (walls[1] == false || paredIzquierda.activeSelf == false)
        {
            paredIzquierda.SetActive(false);
            walls[1] = false;
        }
        if (walls[2] == false || paredArriba.activeSelf == false)
        {
            paredArriba.SetActive(false);
            walls[2] = false;
        }
        if (walls[3] == false || paredAbajo.activeSelf == false)
        {
            paredAbajo.SetActive(false);
            walls[3] = false;
        }
    }
}

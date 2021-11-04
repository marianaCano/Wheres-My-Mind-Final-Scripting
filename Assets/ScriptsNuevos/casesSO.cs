using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "channel", menuName = "ScriptableObjects/caseSO", order = 1)]
public class casesSO : ScriptableObject
{
    public event UnityAction<int> OnJulianHit;

    public void characterFound(Personajes persoFound)
    {
        OnJulianHit?.Invoke(persoFound.GetCharacterType());
        //Debug.Log(persoFound.GetCharacterType());
    }

}

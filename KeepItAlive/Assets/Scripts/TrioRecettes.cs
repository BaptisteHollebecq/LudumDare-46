using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct TrioPot
{
    [SerializeField] public Objets slot1;
    [SerializeField] public Objets slot2;
    [SerializeField] public Objets slot3;
    [SerializeField] public GameObject Result;
}

[CreateAssetMenu]
public class TrioRecettes : ScriptableObject
{
    public List<TrioPot> Recettes;
}

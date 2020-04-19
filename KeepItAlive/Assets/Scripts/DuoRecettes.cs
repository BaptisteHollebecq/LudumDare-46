using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DuoPot
{
    [SerializeField] public Objets slot1;
    [SerializeField] public Objets slot2;
    [SerializeField] public GameObject Result;
}

[CreateAssetMenu]
public class DuoRecettes : ScriptableObject
{
    public List<DuoPot> Recettes;
}

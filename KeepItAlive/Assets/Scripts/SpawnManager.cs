using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> Items = new List<GameObject>();

    [HideInInspector]
    public List<GameObject> ItemsModul = new List<GameObject>();
    //
    public List<GameObject> Used = new List<GameObject>();
    [HideInInspector]
    public List<Transform> Spawns = new List<Transform>();
    [HideInInspector]
    public List<Transform> SpawnAvailable = new List<Transform>();


    private void Awake()
    {
        Used = new List<GameObject>();

        ResetSpawned();
        GetAllChild();
        SpawnItems();

    }

    public void ResetSpawned()
    {
        ItemsModul = new List<GameObject>();
        foreach (GameObject obj in Items)
        {
            if (obj.layer != 11)
                ItemsModul.Add(obj);
        }
    }

    void SpawnItems()
    {
        foreach (Transform spawn in Spawns)
        {
            int tmp;
            tmp = Random.Range(0, ItemsModul.Count);

            var inst = Instantiate(ItemsModul[tmp], spawn.position, spawn.rotation);
            ItemsModul.RemoveAt(tmp);
            if (ItemsModul.Count == 0)
                ResetSpawned();
        }
        ResetSpawned();
    }

    void GetAllChild()
    {
        foreach (Transform child in transform)
        {
            Spawns.Add(child);
        }
    }
}

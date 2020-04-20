
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> Items = new List<GameObject>();


    [HideInInspector]
    public List<GameObject> ItemsModul = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> Used = new List<GameObject>();
    private List<GameObject> FirstSpawn = new List<GameObject>();


    [HideInInspector]
    public List<Transform> Spawns = new List<Transform>();
    [HideInInspector]
    public List<Transform> SpawnAvailable = new List<Transform>();


    int tmp;

    private void Awake()
    {

        ResetFirstSpawned();
        ResetSpawned();
        GetAllChild();
        SpawnItems();

    }

    public void ResetFirstSpawned()
    {
        ItemsModul = new List<GameObject>();
        foreach (GameObject obj in Items)
        {
            if (obj.layer != 11)
                FirstSpawn.Add(obj);

            //ItemsModul.Add(obj);
        }
    }

    public void ResetSpawned()
    {
        ItemsModul = new List<GameObject>();
        foreach (GameObject obj in Items)
        {
            ItemsModul.Add(obj);
        }
    }


    void SpawnItems()
    {
        foreach (Transform spawn in Spawns)
        {
            tmp = Random.Range(0, FirstSpawn.Count);

            var inst = Instantiate(FirstSpawn[tmp], spawn.position, spawn.rotation);
            FirstSpawn.RemoveAt(tmp);
            if (FirstSpawn.Count == 0)
                ResetFirstSpawned();
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

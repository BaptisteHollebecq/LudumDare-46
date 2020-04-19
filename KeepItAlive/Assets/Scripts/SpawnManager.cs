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
    [HideInInspector]
    public List<Transform> Spawns = new List<Transform>();
    [HideInInspector]
    public List<Transform> SpawnAvailable = new List<Transform>();

    private void Awake()
    {
        ResetSpawned();
        GetAllChild();
        SpawnItems();

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
            int tmp;
            do
            {
                tmp = Random.Range(0, ItemsModul.Count);
            } while (ItemsModul[tmp].GetComponent<Objets>().ItemIndex > 22);

            var inst = Instantiate(ItemsModul[tmp], spawn.position, spawn.rotation);
            ItemsModul.RemoveAt(tmp);
            if (ItemsModul.Count <13)
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

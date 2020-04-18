using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    Objets wanted;
    GameObject item;
    Objets itemObject;

    public SpawnManager manager;

    int Success = 0;


    private void Update()
    {
        if (wanted == null)
        {
            var tmp = Random.Range(0, manager.ItemsModul.Count);
            wanted = manager.ItemsModul[tmp].GetComponent<Objets>();
            manager.ItemsModul.RemoveAt(tmp);
        }
        if (manager.ItemsModul.Count == 0)
            manager.ResetSpawned();

        Debug.Log(wanted);

        if (Success >= 10)
        {
            RespawnStuffs();
        }
    }

    private void RespawnStuffs()
    {
        Success = 0;
        manager.SpawnAvailable = new List<Transform>();

        foreach (Transform spawn in manager.Spawns)
        {
            if (spawn.GetComponent<Spawn>().available == true)
                manager.SpawnAvailable.Add(spawn);
        }

        foreach (GameObject obj in manager.Used)
        {
            var tmp = Random.Range(0, manager.SpawnAvailable.Count);

            obj.SetActive(true);

            obj.transform.position = manager.SpawnAvailable[tmp].transform.position;
            obj.transform.rotation = manager.SpawnAvailable[tmp].transform.rotation;

            manager.SpawnAvailable.RemoveAt(tmp);
        }
        manager.Used = new List<GameObject>();
    }

    public void NewSpawnAvailable(Transform spawn)
    {
        manager.SpawnAvailable.Add(spawn);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "objet")
        {
            item = collision.gameObject;
            itemObject = item.GetComponent<Objets>();

            if (itemObject.ItemIndex != wanted.ItemIndex)
            {
                itemObject.Bond();
            }
            else
            {
                manager.Used.Add(item);
                Success++;
                item.SetActive(false);
                wanted = null;
            }
        }
    }
}
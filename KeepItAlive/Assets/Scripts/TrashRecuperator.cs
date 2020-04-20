using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class TrashRecuperator : MonoBehaviour
{
    public SpawnManager manager;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "objet")
        {
            collision.gameObject.SetActive(false);
            manager.Used.Add(collision.gameObject);
        }
    }
}

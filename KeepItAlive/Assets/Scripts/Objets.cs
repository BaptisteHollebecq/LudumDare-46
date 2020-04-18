using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Objets : MonoBehaviour
{
    public int ItemIndex;


    Vector3 spawnPos;
    Quaternion spawnRot;
    Rigidbody rb;

     private void Awake()
    {
        spawnPos = transform.position;
        spawnRot = transform.rotation;
        transform.tag = "objet";
        rb = GetComponent<Rigidbody>();
    }


    public void Respawn()
    {
        rb.velocity = Vector3.zero;
        transform.position = spawnPos;
        transform.rotation = spawnRot;
    }

    public void Bond()
    {
        rb.velocity = new Vector3(Random.Range(-0.5f,0.5f), 1, Random.Range(-0.5f, 0.5f)) * 20f;
        /*rb.velocity = Vector3.up * 7f;*/
    }
}

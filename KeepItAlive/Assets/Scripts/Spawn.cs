using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
     public bool available;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "objet")
            available = false;  
    }

    private void OnTriggerExit(Collider other)
    {
        available = true;
    }
}

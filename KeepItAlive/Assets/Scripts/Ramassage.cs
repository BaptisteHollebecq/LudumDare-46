using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramassage : MonoBehaviour
{
    public Transform Hand;
    public LayerMask Mask;
    public float Range = 2f;
    public float Power = 100f;

    bool HandFull = false;
    GameObject inHand;

    private void Start()
    {
        Mask = ~Mask;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!HandFull)
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Range, Mask))
                {
                    if (hit.transform.tag == "objet")
                    {
                        inHand = hit.transform.gameObject;
                        HandFull = true;
                        inHand.transform.parent = Hand;
                        inHand.transform.localPosition = new Vector3(0, 0, 0);
                        inHand.transform.localRotation = Hand.rotation;
                        inHand.GetComponent<Rigidbody>().isKinematic = true;
                        Debug.Log(inHand.GetComponent<Objets>());
                        
                    }
                }
            }
            else
            {
                inHand.transform.parent = null;
                inHand.GetComponent<Rigidbody>().isKinematic = false;
                HandFull = false;
                inHand = null;
            }
        }
        if (Input.GetMouseButtonDown(1) && HandFull)
        {
            inHand.transform.parent = null;
            inHand.GetComponent<Rigidbody>().isKinematic = false;
            inHand.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * Power;
            HandFull = false;
            inHand = null;
        }

    }

}

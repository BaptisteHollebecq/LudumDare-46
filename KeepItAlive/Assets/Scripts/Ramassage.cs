using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ramassage : MonoBehaviour
{
    public Transform Hand;
    public LayerMask Mask;
    public float Range = 2f;
    public float Power = 100f;

    bool HandFull = false;
    GameObject inHand;
    MouseLook mouseCtrl;

    bool canQuit = false;
    bool froze = false;

    private void Start()
    {
        Mask = ~Mask;
        mouseCtrl = Camera.main.GetComponent<MouseLook>();
    }

    private void Update()
    {
        if (!mouseCtrl.freeze)
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
                            //inHand.transform.localRotation = Hand.rotation;
                            inHand.GetComponent<Rigidbody>().isKinematic = true;
                            //Debug.Log(inHand.GetComponent<Objets>());

                        }
                        if (hit.transform.tag == "chaudron")
                        {
                            hit.transform.GetChild(0).GetComponent<Chaudron>().CheckCraft();
                        }
                        if (hit.transform.tag == "Livre")
                        {
                            hit.transform.GetComponent<Livre>().NextPage();
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
            if (Input.GetMouseButtonDown(1))
            {
                if (HandFull)
                {
                    inHand.transform.parent = null;
                    inHand.GetComponent<Rigidbody>().isKinematic = false;
                    inHand.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * Power;
                    HandFull = false;
                    inHand = null;
                }
                else
                {
                    RaycastHit hit;
                    if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Range, Mask))
                    {
                        if (hit.transform.tag == "Livre")
                        {
                            hit.transform.GetComponent<Livre>().PreviousPage();
                        }
                    }
                }
            }
        }
        else
        {
            if (!froze)
            {
                froze = true;
                StartCoroutine(YouCanQuit());
            }
            if (Input.anyKey && canQuit)
                SceneManager.LoadScene("MenuMain");
        }
    }

    private IEnumerator YouCanQuit()
    {
        yield return new WaitForSeconds(1);
        canQuit = true;
    }
}

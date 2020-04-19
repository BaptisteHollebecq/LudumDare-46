using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MAINMENU : MonoBehaviour
{

    public float transition = 1;
    public List<GameObject> Buttons;

    bool inMenu = false;
    GameObject BackButton;
    Transform actualPos;

    private void Awake()
    {
        Button.OnClicked += MoveToPivot;
        BackButton = transform.GetChild(0).gameObject;
        BackButton.SetActive(false);
    }

    private void OnDestroy()
    {
        Button.OnClicked -= MoveToPivot;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(Ray, out hit))
            {

                if (hit.transform.gameObject.layer == 5)
                {
                    hit.transform.GetComponent<Button>().Move();
                }
            }
        }
    }


    private void MoveToPivot(Transform pos)
    {
        if (!inMenu)
        {
            inMenu = true;
            foreach (GameObject obj in Buttons)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            inMenu = false;
            foreach (GameObject obj in Buttons)
            {
                obj.SetActive(true);
            }
            BackButton.SetActive(false);
        }


        StartCoroutine(MoveToPivot(pos, transition));
    }


    IEnumerator MoveToPivot(Transform pivot, float duration)
    {
        var initPos = transform.position;
        var initRot = transform.rotation;

        for (float f = 0; f < 1; f += Time.deltaTime / duration)
        {
            transform.position = Vector3.Lerp(initPos, pivot.position, f);
            transform.rotation = Quaternion.Lerp(initRot, pivot.rotation, f);
            yield return null;
        }

        transform.position = pivot.position;
        transform.rotation = pivot.rotation;

        actualPos = pivot;
        CheckActualPos();
    }

    private void CheckActualPos()
    {
        //Debug.Log("-"+actualPos.name+"-" + "   -ControlsPos-");
        switch (actualPos.name)
        {
            case "PlayPos":
                {
                    SceneManager.LoadScene("MainScene");
                    break;
                }
            case "QuitPos":
                {
                    Application.Quit();
                    break;
                }
            case "ControlsPos":
                {
                    BackButton.SetActive(true);
                    break;
                }
            case "CreditPos":
                {
                    BackButton.SetActive(true);
                    break;
                }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaudron : MonoBehaviour
{
    GameObject slot1 = null;
    GameObject slot2 = null;
    GameObject slot3 = null;
    List<GameObject> Used = new List<GameObject>();

    Transform exp;

    private void Start()
    {
        exp = transform.GetChild(0);
    }

    private void Update()
    {
        Debug.Log("Slot1 === " + slot1);
        Debug.Log("Slot2 === " + slot2);
        Debug.Log("Slot3 === " + slot3);
    }

    public void CheckRecipe()
    {
        if (slot1 != null)
        {
            int first = slot1.GetComponent<Objets>().ItemIndex;
            if (slot2 != null)
            {
                int second = slot2.GetComponent<Objets>().ItemIndex;
                if (CheckDuoRecipe(first, second) == 1)
                {
                    if (slot3 != null)
                    {
                        int third = slot3.GetComponent<Objets>().ItemIndex;
                        if (CheckTrioRecipe(first, second, third) == 1)
                            Expulse();
                    }
                    else
                        Expulse();
                }
            }
            else
                Expulse();
        }
    }

    private int CheckTrioRecipe(int first, int second, int third)
    {
        int[,] possibilities = GetTrio(first);
        if (possibilities[0,0] != 0)
        {
            for (int i = 0; i < possibilities.GetUpperBound(0); i++)
            {
                if (possibilities[i,0] == second && possibilities[i, 1] == third)
                {
                    CreateTrioPot(first, second, third);
                    return 0;
                }
            }
        }
        return 1;
    }

    private void CreateTrioPot(int first, int second, int third)
    {
        throw new NotImplementedException(); //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    }

    private int[,] GetTrio(int first)
    {
        switch (first)
        {
            case 1:
                {
                    int[,] tab = new int[2, 2];
                    tab[0, 0] = 0;
                    return tab;
                }
            case 2:
                {
                    int[,] tab = new int[2, 2];
                    tab[0, 0] = 0;
                    return tab;
                }
            case 3:
                {
                    int[,] tab = new int[2, 2];
                    tab[0, 0] = 0;
                    return tab;
                }
            case 4:
                {
                    int[,] tab = new int[2, 2];
                    tab[0, 0] = 0;
                    return tab;
                }
            case 5:
                {
                    int[,] tab = new int[2, 2];
                    tab[0, 0] = 7;
                    tab[0, 1] = 10;
                    tab[1, 0] = 10;
                    tab[1, 1] = 7;
                    return tab;
                }
            case 6:
                {
                    int[,] tab = new int[2, 2];
                    tab[0, 0] = 7;
                    tab[0, 1] = 9;
                    tab[1, 0] = 9;
                    tab[1, 1] = 7;
                    return tab;
                }
            case 7:
                {
                    int[,] tab = new int[4, 2];
                    tab[0, 0] = 9;
                    tab[0, 1] = 6;
                    tab[1, 0] = 6;
                    tab[1, 1] = 9;

                    tab[2, 0] = 10;
                    tab[2, 1] = 5;
                    tab[3, 0] = 5;
                    tab[3, 1] = 10;
                    return tab;
                }
            case 8:
                {
                    int[,] tab = new int[2, 2];
                    tab[0, 0] = 0;
                    return tab;
                }
            case 9:
                {
                    int[,] tab = new int[2, 2];
                    tab[0, 0] = 6;
                    tab[0, 1] = 7;
                    tab[1, 0] = 7;
                    tab[1, 1] = 6;
                    return tab;
                }
            case 10:
                {
                    int[,] tab = new int[2, 2];
                    tab[0, 0] = 7;
                    tab[0, 1] = 5;
                    tab[1, 0] = 5;
                    tab[1, 1] = 7;
                    return tab;
                }
            case 11:
                {
                    int[,] tab = new int[2, 2];
                    tab[0, 0] = 0;
                    return tab;
                }
            case 12:
                {
                    int[,] tab = new int[2, 2];
                    tab[0, 0] = 0;
                    return tab;
                }
            case 13:
                {
                    int[,] tab = new int[2, 2];
                    tab[0, 0] = 20;
                    tab[0, 1] = 16;
                    tab[1, 0] = 16;
                    tab[1, 1] = 20;
                    return tab;
                }
            case 14:
                {
                    int[,] tab = new int[2, 2];
                    tab[0, 0] = 0;
                    return tab;
                }
            case 15:
                {
                    int[,] tab = new int[2, 2];
                    tab[0, 0] = 0;
                    return tab;
                }
            case 16:
                {
                    int[,] tab = new int[2, 2];
                    tab[0, 0] = 13;
                    tab[0, 1] = 20;
                    tab[1, 0] = 20;
                    tab[1, 1] = 13;
                    return tab;
                }
            case 17:
                {
                    int[,] tab = new int[2, 2];
                    tab[0, 0] = 0;
                    return tab;
                }
            case 18:
                {
                    int[,] tab = new int[2, 2];
                    tab[0, 0] = 0;
                    return tab;
                }
            case 19:
                {
                    int[,] tab = new int[2, 2];
                    tab[0, 0] = 0;
                    return tab;
                }
            case 20:
                {
                    int[,] tab = new int[2, 2];
                    tab[0, 0] = 13;
                    tab[0, 1] = 16;
                    tab[1, 0] = 16;
                    tab[1, 1] = 13;
                    return tab;
                }
            case 21:
                {
                    int[,] tab = new int[2, 2];
                    tab[0, 0] = 0;
                    return tab;
                }
            case 22:
                {
                    int[,] tab = new int[2, 2];
                    tab[0, 0] = 0;
                    return tab;
                }
            default:
                {
                    int[,] tab = new int[2, 2];
                    tab[0, 0] = 0;
                    return tab;
                }
        }
    }

    private int CheckDuoRecipe(int first, int second)
    {
        int[] possibilities = GetDuo(first);
        if (possibilities[0] != 0)
        {
            for (int i = 0; i < possibilities.Length; i++)
            {
                if (possibilities[i] == second)
                {
                    CreateDuoPot(first, second);

                    return 0;
                }
            }
        }
        return 1;
    }


    private void CreateDuoPot(int first, int second)
    {
        
        if (slot3 != null)
            Expulse();
    }

    private int[] GetDuo(int first)
    {
        switch (first)
        {
            case 1:
                {
                    int[] tab = new int[] { 3 };
                    return tab;
                }
            case 2:
                {
                    int[] tab = new int[] { 12 };
                    return tab;
                }
            case 3:
                {
                    int[] tab = new int[] { 1, 22 };
                    return tab;
                }
            case 4:
                {
                    int[] tab = new int[] { 6, 17 };
                    return tab;
                }
            case 5:
                {
                    int[] tab = new int[] { 0 };
                    return tab;
                }
            case 6:
                {
                    int[] tab = new int[] { 4 };
                    return tab;
                }
            case 7:
                {
                    int[] tab = new int[] { 0 };
                    return tab;
                }
            case 8:
                {
                    int[] tab = new int[] { 20 };
                    return tab;
                }
            case 9:
                {
                    int[] tab = new int[] { 0 };
                    return tab;
                }
            case 10:
                {
                    int[] tab = new int[] { 0 };
                    return tab;
                }
            case 11:
                {
                    int[] tab = new int[] { 15 };
                    return tab;
                }
            case 12:
                {
                    int[] tab = new int[] { 2 };
                    return tab;
                }
            case 13:
                {
                    int[] tab = new int[] { 0 };
                    return tab;
                }
            case 14:
                {
                    int[] tab = new int[] { 18 };
                    return tab;
                }
            case 15:
                {
                    int[] tab = new int[] { 11 };
                    return tab;
                }
            case 16:
                {
                    int[] tab = new int[] { 21 };
                    return tab;
                }
            case 17:
                {
                    int[] tab = new int[] { 4 };
                    return tab;
                }
            case 18:
                {
                    int[] tab = new int[] { 14, 22 };
                    return tab;
                }
            case 19:
                {
                    int[] tab = new int[] { 0 };
                    return tab;
                }
            case 20:
                {
                    int[] tab = new int[] { 8 };
                    return tab;
                }
            case 21:
                {
                    int[] tab = new int[] { 16 };
                    return tab;
                }
            case 22:
                {
                    int[] tab = new int[] { 3, 18};
                    return tab;
                }
            default:
                {
                    int[] tab = new int[] { 0 };
                    return tab;
                }

        }
    }






    public void Expulse()
    {
        if (slot1 != null)
        {
            slot1.transform.position = exp.position;
            slot1.SetActive(true);
            slot1.GetComponent<Objets>().Expulse();
            slot1 = null;
        }
        if (slot2 != null)
        {
            slot2.transform.position = exp.position;
            slot2.SetActive(true);
            slot2.GetComponent<Objets>().Expulse();
            slot2 = null;
        }
        if (slot3 != null)
        {
            slot3.transform.position = exp.position;
            slot3.SetActive(true);
            slot3.GetComponent<Objets>().Expulse();
            slot3 = null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "objet")
        {
            if (slot1 == null)
            {
                slot1 = collision.gameObject;
                collision.gameObject.SetActive(false);
                Used.Add(collision.gameObject);
            }
            else if (slot2 == null)
            {
                slot2 = collision.gameObject;
                collision.gameObject.SetActive(false);
                Used.Add(collision.gameObject);
            }
            else if (slot3 == null)
            {
                slot3 = collision.gameObject;
                collision.gameObject.SetActive(false);
                Used.Add(collision.gameObject);
            }
        }
    }
}

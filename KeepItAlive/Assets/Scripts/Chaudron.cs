using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaudron : MonoBehaviour
{
    public DuoRecettes DuoRecette;
    public TrioRecettes TrioRecette;

    public SpawnManager manager;


    GameObject slot1 = null;
    GameObject slot2 = null;
    GameObject slot3 = null;
    List<GameObject> Used = new List<GameObject>();

    Transform exp;

    BoxCollider box;

    private void Start()
    {
        exp = transform.GetChild(0);
        box = GetComponent<BoxCollider>();
    }

    private void Update()
    {
 /*       Debug.Log("Slot1 === " + slot1);
        Debug.Log("Slot2 === " + slot2);
        Debug.Log("Slot3 === " + slot3);*/
    }

    #region old
  /*  public void CheckRecipe()
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
        foreach(DuoPot pot in DuoRecette.Recettes)
        {
            if ((pot.slot1 == slot1 && pot.slot1 == slot2)&&(pot.slot2 == slot1 && pot.slot2 == slot2))
            {
                //var inst = Instantiate()                  faire les pot
                //inst.GetComponent<Objets>().Expulse();
            }
        }
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
    }*/

    #endregion

    #region test

    public void CheckCraft()
    {

        if (slot1 != null)
        {
            Objets obj1 = slot1.GetComponent<Objets>();
            if (slot2 != null)
            {
                Objets obj2 = slot2.GetComponent<Objets>();
                foreach (DuoPot pot in DuoRecette.Recettes)
                {
                    if ((pot.slot1.ItemIndex == obj1.ItemIndex || pot.slot1.ItemIndex == obj2.ItemIndex) && (pot.slot2.ItemIndex == obj1.ItemIndex || pot.slot2.ItemIndex == obj2.ItemIndex))
                    { 
                        Debug.Log("SPAWNED!!!!!!!!!!!!!!!!!!!");
                        var inst = Instantiate(pot.Result, exp.position, exp.rotation);
                        inst.GetComponent<Objets>().Expulse();
                        manager.Used.Add(slot1);
                        slot1.SetActive(false);
                        manager.Used.Add(slot2);
                        slot2.SetActive(false);
                        slot1 = null;
                        slot2 = null;
                        if (slot3 != null)
                            Expulse();
                        break;
                    }
                }
                if (slot3 != null)
                {
                    Objets obj3 = slot3.GetComponent<Objets>();
                    foreach (TrioPot pot in TrioRecette.Recettes)
                    {
                        if ((pot.slot1.ItemIndex == obj1.ItemIndex || pot.slot1.ItemIndex == obj2.ItemIndex || pot.slot1.ItemIndex == obj3.ItemIndex) &&
                            (pot.slot2.ItemIndex == obj1.ItemIndex || pot.slot2.ItemIndex == obj2.ItemIndex || pot.slot2.ItemIndex == obj3.ItemIndex) &&
                            (pot.slot3.ItemIndex == obj1.ItemIndex || pot.slot3.ItemIndex == obj2.ItemIndex || pot.slot3.ItemIndex == obj3.ItemIndex))
                        {
                            Debug.Log("SPAWNED!!!!!!!!!!!!!!!!!!!");
                            var inst = Instantiate(pot.Result, exp.position, exp.rotation);
                            inst.GetComponent<Objets>().Expulse();
                            manager.Used.Add(slot1);
                            slot1.SetActive(false);
                            manager.Used.Add(slot2);
                            slot2.SetActive(false);
                            manager.Used.Add(slot3);
                            slot2.SetActive(false);
                            slot1 = null;
                            slot2 = null;
                            slot3 = null;
                            break;
                        }
                    }
                }
                Expulse();
            }
            else
                Expulse();
        }
    }

    #endregion


    public void Expulse()
    {
        box.enabled = false;
        StartCoroutine(ActiveCollider());

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

    private IEnumerator ActiveCollider()
    {
        yield return new WaitForSeconds(1);
        box.enabled = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "objet")
        {
            if (other.transform.parent == null)
            {
                if (slot1 == null)
                {
                    slot1 = other.gameObject;
                    other.gameObject.SetActive(false);
                    Used.Add(other.gameObject);
                }
                else if (slot2 == null)
                {
                    slot2 = other.gameObject;
                    other.gameObject.SetActive(false);
                    Used.Add(other.gameObject);
                }
                else if (slot3 == null)
                {
                    slot3 = other.gameObject;
                    other.gameObject.SetActive(false);
                    Used.Add(other.gameObject);
                }
            }
        }
    }

}

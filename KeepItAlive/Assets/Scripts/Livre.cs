using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Livre : MonoBehaviour
{
    public List<Material> Pages;

    MeshRenderer visu;
    Material page;

    int pageIndex = 0;

    private void Start()
    {
        visu = GetComponent<MeshRenderer>();
        page = visu.materials[2];
        //Debug.Log("la page est  === " + page.name);



        page = Pages[pageIndex];
    }

    public void NextPage()
    {
        pageIndex++;
        if (pageIndex > Pages.Count - 1)
            pageIndex = 0;
        page = Pages[pageIndex];
    }

    public void PreviousPage()
    {
        pageIndex--;
        if (pageIndex < 0)
            pageIndex = Pages.Count - 1;
        page = Pages[pageIndex];
    }
}

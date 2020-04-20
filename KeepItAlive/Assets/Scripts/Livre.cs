using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Livre : MonoBehaviour
{
    public List<Material> Pages;

    Renderer visu;
    Material[] sharedpage;
    Material page;

    int pageIndex = 5;

    //public Soundmanager soundManager;

    private void Start()
    {
        visu = GetComponent<Renderer>();
        visu.enabled = true;

        sharedpage = visu.materials;

        page = Pages[pageIndex];

        sharedpage[2] = page;

        visu.sharedMaterials = sharedpage;
    }

    public void NextPage()
    {
        pageIndex++;
        if (pageIndex > Pages.Count - 1)
            pageIndex = 0;
        page = Pages[pageIndex];
        sharedpage = visu.materials;
        sharedpage[2] = page;
        visu.sharedMaterials = sharedpage;
        Soundmanager.PlaySound("Sheet");
    }

    public void PreviousPage()
    {
        pageIndex--;
        if (pageIndex < 0)
            pageIndex = Pages.Count - 1;
        page = Pages[pageIndex];
        sharedpage = visu.materials;
        sharedpage[2] = page;
        visu.sharedMaterials = sharedpage;
        Soundmanager.PlaySound("Sheet");
    }
}

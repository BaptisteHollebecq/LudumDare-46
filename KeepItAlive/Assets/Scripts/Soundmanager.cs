using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour
{

    public static AudioClip brewSound, acceptSound, declineSound, dieSound, sheetSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        brewSound = Resources.Load<AudioClip>("Brew");
        //acceptSound = Resources.Load<AudioClip>("Accept");
        //declineSound = Resources.Load<AudioClip>("Decline");
        //dieSound = Resources.Load<AudioClip>("Die");
        sheetSound = Resources.Load<AudioClip>("Sheet");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch(clip) 
        {
            case "Brew":
                audioSrc.PlayOneShot(brewSound);
                break;
            /*case "Accept":
                audioSrc.PlayOneShot(acceptSound);
                break;
            case "Decline":
                audioSrc.PlayOneShot(declineSound);
                break;
            case "Die":
                audioSrc.PlayOneShot(dieSound);
                break;*/
            case "Sheet":
                audioSrc.PlayOneShot(sheetSound);
                break;

        }
    }


}

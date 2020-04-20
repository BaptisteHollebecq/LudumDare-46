using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Portals : MonoBehaviour
{
    Objets wanted;
    GameObject item;
    Objets itemObject;
    public float remainingSec = 45f;
    public float timegain = 30f;
    float remainingMin = 0f;
    int timeLeft;
    float score = 0;

    //public Soundmanager soundManager;

    public SpawnManager manager;


    public int difficultyStade1 = 15;
    public int difficultyStade2 = 30;

    int Success = 0;
    int Difficulty = 0;
    int tmp;

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Text text;
    public Text textScore;
    public ParticleSystem Win;

    MouseLook mouseCtrl;

    [System.Obsolete]
    private void Start()
    {
        mouseCtrl = Camera.main.GetComponent<MouseLook>();
        int seed = Random.Range(0, 99999);
        Random.InitState(seed);

    }

    private void Update()
    {
        if (!mouseCtrl.freeze)
        {
            remainingSec -= Time.deltaTime;
            score += Time.deltaTime;
        }
       
        if (remainingSec < 1)
        {
            if (remainingMin != 0)
            {
                remainingMin--;
                remainingSec += 60;
            }
            else
            {
                //FONCTION FIN DU JEU 
                mouseCtrl.freeze = true;
                text.enabled = false;
                textScore.enabled = true;
                textScore.text = "THE DEMON DIED\n\nYOU KEPT HIM ALIVE FOR\n" + Mathf.Floor(score) + " SECONDES";

                Soundmanager.PlaySound("Die");
            }
        }


        if (wanted == null)
        {
            

            if (Difficulty <= difficultyStade1)
            {
                tmp = GetRandomNonPot(true);
            }
            else if (Difficulty > difficultyStade1 && Difficulty <= difficultyStade2)
            {
                tmp = Random.Range(0, manager.ItemsModul.Count);
            }
            else
            {
                tmp = GetRandomNonPot(false);
            }

            wanted = manager.ItemsModul[tmp].GetComponent<Objets>();
            manager.ItemsModul.RemoveAt(tmp);

        }
        if (manager.ItemsModul.Count == 0)
            manager.ResetSpawned();



        spriteRenderer.sprite = wanted.ItemSprite;

        string txt = "Remaining Time : ";
        if (remainingSec >= 60)
        {
            remainingMin++;
            remainingSec -= 60;
        }
        if (remainingMin != 0)
        {
            txt += Mathf.Floor(remainingMin);
            txt += " Minutes ";
        }
        txt += Mathf.Floor(remainingSec % 60).ToString() + " Secondes";





        text.text = txt;

        //Debug.Log(wanted.name);


        if (Success >= 10)
        {
            RespawnStuffs();
        }
    }

    private void RespawnStuffs()
    {
        Success = 0;
        manager.SpawnAvailable = new List<Transform>();

        foreach (Transform spawn in manager.Spawns)
        {
            if (spawn.GetComponent<Spawn>().available == true)
                manager.SpawnAvailable.Add(spawn);
        }

        foreach (GameObject obj in manager.Used)
        {
            var tmp = Random.Range(0, manager.SpawnAvailable.Count);

            obj.SetActive(true);
            obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
            obj.transform.position = manager.SpawnAvailable[tmp].transform.position;
            obj.transform.rotation = manager.SpawnAvailable[tmp].transform.rotation;

            manager.SpawnAvailable.RemoveAt(tmp);
        }
        manager.Used = new List<GameObject>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "objet")
        {
            item = collision.gameObject;
            itemObject = item.GetComponent<Objets>();

            if (itemObject.ItemIndex != wanted.ItemIndex)
            {
                animator.SetTrigger("Deny");
                itemObject.Bond();
                Soundmanager.PlaySound("Decline");
            }
            else
            {
                animator.SetTrigger("Accept");
                remainingSec += timegain;
                Soundmanager.PlaySound("Accept");
                Win.Play();

                if (item.layer != 11)
                    manager.Used.Add(item);
                Success++;
                Difficulty++;
                item.SetActive(false);
                wanted = null;
            }
        }
    }


    private int GetRandomNonPot(bool b)
    {
        Random.InitState(Random.Range(1,8));
        int tmp;
        if (b)
        {
            do
            {
                tmp = Random.Range(0, manager.ItemsModul.Count);
            } while (manager.ItemsModul[tmp].layer == 11);
        }
        else
        {
            do
            {
                tmp = Random.Range(0, manager.ItemsModul.Count);
            } while (manager.ItemsModul[tmp].layer != 11);
        }
        return tmp;
    }
}
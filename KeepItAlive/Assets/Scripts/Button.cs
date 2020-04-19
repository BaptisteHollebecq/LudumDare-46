using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public static event System.Action<Transform> OnClicked;
    public Transform CamPos;

    public void Move()
    {
        OnClicked?.Invoke(CamPos);
    }
}

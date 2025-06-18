using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("Interactable - Base")]
    public bool displayDebugMessage = false;

    public virtual void Interact()
    {
        if (displayDebugMessage)
            Debug.Log("Interacted with " + gameObject.name);
    }
}
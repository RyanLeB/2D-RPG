using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerInteraction : MonoBehaviour
{

    [Header("Current object the character is colliding with")]
    public GameObject currentInterObject = null;
    public InteractionObject currentInterObjScript = null;


    [Header("Fading Text")]
    public TMP_Text interactMessage;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentInterObject == true)
        {
            if (currentInterObjScript.info == true)
            {
                currentInterObjScript.Info();
            }

            if (currentInterObjScript.pickup == true)
            {
                currentInterObjScript.Pickup();
            }

        }
            
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("InteractObject") == true)
        {
            currentInterObject = other.gameObject;
            currentInterObjScript = currentInterObject.GetComponent<InteractionObject>();
            interactMessage.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("InteractObject") == true)
        {
            currentInterObject = null;
            interactMessage.gameObject.SetActive(false);
        }
    }
}
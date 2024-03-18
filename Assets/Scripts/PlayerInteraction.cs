using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject currentInterObj = null;
    public InteractionObject currentInterObjScript = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentInterObj == true)
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
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("InteractObject") == true)
        {
            currentInterObj = null;

        }
    }
}
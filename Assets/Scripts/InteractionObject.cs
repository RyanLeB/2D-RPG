using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.VersionControl;

public class InteractionObject : MonoBehaviour
{
    [Header("Info")]
    public bool info;
    public string message;
    public TextMeshPro infoText;


    [Header("Pickups")]
    public bool pickup;
    
    public void Start()
    {
        
        
    }


    public void Info()
    {
        // Log message
        Debug.Log(message);

        
        if (infoText != null)
        {
            infoText.text = message;

            
            StartCoroutine(FadeText());
        }
        else
        {
            Debug.LogError("infoText is not assigned!");
        }
    }


    public void Pickup()
    {
        Debug.Log("You Picked Up " + this.gameObject.name);
        this.gameObject.SetActive(false);
    }

    


    IEnumerator ShowInfo(string message, float secondsDelay)
    {
        infoText.text = message;
        
        yield return new WaitForSeconds(secondsDelay);
        infoText.text = null;

    }

    IEnumerator FadeText()
    {
        if (infoText == null)
        {
            Debug.LogError("infoText is not assigned!");
            yield break;
        }

        
        Color initialColor = infoText.color;

        
        for (float t = 0; t < 1; t += Time.deltaTime / 2f)
        {
            float alpha = Mathf.Lerp(0, 1, t);
            infoText.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            yield return null;
        }

        
        yield return new WaitForSeconds(3f);

        
        for (float t = 0; t < 1; t += Time.deltaTime / 2f)
        {
            float alpha = Mathf.Lerp(1, 0, t);
            infoText.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            yield return null;
        }

        
        infoText.text = null;
    }

}




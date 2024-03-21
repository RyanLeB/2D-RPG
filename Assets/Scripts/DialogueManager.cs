using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("References")]
    
    public GameObject dialogueUI;
    public Text dialogueText;
    public GameObject player;
    public Animator animator;

    // Queue for dialogue

    private Queue<string> dialogueQueue;


    void Start()
    {
        dialogueQueue = new Queue<string>();
    }


    public void StartDialogue(string[] sentences)
    {
        // Clear the queue
        dialogueQueue.Clear();
        dialogueUI.SetActive(true);

        // Disable player movement
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<PlayerInteraction>().enabled = false;

        // Set the animator speed to 0
        animator.SetFloat("Speed", 0);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        foreach (string currentLine in sentences)
        {
            dialogueQueue.Enqueue(currentLine);
        }
        
        // Display the next sentence
        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            //Debug.Log("there is nothing left in the queue...");
            return;
        }

        string currentLine = dialogueQueue.Dequeue();

        dialogueText.text = currentLine;
    }

    // End dialogue Method
    void EndDialogue()
    {
        dialogueQueue.Clear();
        dialogueUI.SetActive(false);

        // Enable player movement
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<PlayerInteraction>().enabled = true;
    }



}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;
using DG.Tweening;

public class Inventory : MonoBehaviour
{
    private List<Item> items;
    

    public Inventory()
    {
        items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        switch (item.itemType)
        {
            case "Potion":
                // Add a potion to the inventory'
                items.Add(item);
                Debug.Log("Potion Type");
                break;

            case "Stone":
                // Add a stone to the inventory
                items.Add(item);
                Debug.Log("Stone Type");
                FindObjectOfType<QuestManager>().UpdateStoneCountText();

                if (CountStones() == 3)
                {
                    // If it has, find the parent game object
                    GameObject parentObject = GameObject.Find("Portal");
                    if (parentObject != null)
                    {
                        // Find the child game object and activate it
                        Transform childObject = parentObject.transform.Find("GoodPortal");
                        if (childObject != null)
                        {
                            childObject.gameObject.SetActive(true);

                            // Play the sound
                            AudioSource audioSource = childObject.GetComponent<AudioSource>();
                            if (audioSource != null)
                            {
                                audioSource.Play();
                            }

                            
                        }
                        else
                        {
                            Debug.LogError("Child game object not found");
                        }

                    }
                        
                    // Show the text
                    TextMeshProUGUI text = GameObject.Find("PortalText").GetComponent<TextMeshProUGUI>();
                    if (text != null)
                    {
                        text.DOFade(1, 1).OnComplete(() => text.DOFade(0, 1));
                    }

                    else
                    {
                        Debug.LogError("Parent game object not found");
                    }
                }

                break;

            case "Weapon":
                // Add a Weapon to the inventory
                items.Add(item);
                Debug.Log("Weapon Type");
                break;

            case "Statue":
                // Statue interacted with
                items.Add(item);
                Debug.Log("Statue Type");
                break;



            default:
                Debug.LogError("Invalid item type: " + item.itemType);
                break;
        }
    }

    public int CountStones()
    {
        return items.Count(i => i.itemType == "Stone");
    }

    public int CountWeapons()
    {
        return items.Count(i => i.itemType == "Weapon");
    }

    public int CountPotions()
    {
        return items.Count(i => i.itemType == "Potion");
    }
    public int CountStatue()
    {
        return items.Count(i => i.itemType == "Statue");
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public bool ContainsItem(Item item)
    {
        return items.Contains(item);
    }

    public int GetItemCount(Item item)
    {
        return items.Count(i => i == item);
    }
}

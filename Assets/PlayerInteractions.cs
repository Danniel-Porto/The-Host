using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour
{
    Inventory inv;

    //Interactions
    [SerializeField] Text hint;
    [SerializeField] RawImage paperImage;
    bool activeInteraction;
    InteractionProperties properties;
    GameObject interactedObject;

    [Header("Ritual Items")]
    [SerializeField] GameObject litCandlePrefab, saltPrefab;

    private void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            activeInteraction = true;
            properties = other.gameObject.GetComponent<InteractionProperties>();
            interactedObject = other.gameObject;
            string interactionType = properties.interactionType.ToString();
            switch (interactionType)
            {
                case "Paper":
                    hint.text = "Read (E)";
                    hint.enabled = true;
                    break;
                case "Item":
                    hint.text = "Grab (E)";
                    hint.enabled = true;
                    break;
                case "Door":
                    hint.text = "Open (E)";
                    hint.enabled = true;
                    break;
                case "LockedDoor":
                    hint.text = "Open (E) (Locked)";
                    hint.enabled = true;
                    break;
                case "ItemPlacement":
                    hint.text = "Place Item";
                    hint.enabled = true;
                    break;
                default:
                    break;
            }
        }
    }
    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            InteractionProperties properties = other.gameObject.GetComponent<InteractionProperties>();
            string interactionType = properties.interactionType.ToString();
            switch (interactionType)
            {
                case "Paper":
                    ReadText(properties.paperTexture);
                    break;
                case "Item":
                    //TODO Action logic
                    break;
                case "Door":
                    //TODO Action logic
                    break;
                case "LockedDoor":
                    //TODO Action logic
                    break;
                default:
                    break;
            }
        }
    }
    */
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            activeInteraction = false;
            CloseAllInteractionUI();
        }
    }

    private void FixedUpdate()
    {
        if (activeInteraction)
        {
            switch (properties.interactionType.ToString())
            {
                case "Paper":
                    ReadText(properties.paperTexture);
                    break;
                case "Item":
                    GrabItem();
                    break;
                case "Door":
                    OpenDoor();
                    break;
                case "LockedDoor":
                    OpenLockedDoor();
                    break;
                case "ItemPlacement":
                    PlaceItem(properties.itemRequisition.ToString());
                    break;
                default:
                    break;
            }
        }
    }

    private void PlaceItem(string itemRequisition)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (UseItem(itemRequisition))
            {
                switch (itemRequisition)
                {
                    case "Candle":
                        Instantiate(litCandlePrefab, interactedObject.transform.position, interactedObject.transform.rotation);
                        Destroy(interactedObject);
                        activeInteraction = false;
                        inv.placedItems += 1;
                        CloseAllInteractionUI();
                        break;
                    case "Sack":
                        Instantiate(saltPrefab, interactedObject.transform.position + new Vector3(0f, -0.21f, 0f), interactedObject.transform.rotation);
                        Destroy(interactedObject);
                        activeInteraction = false;
                        inv.placedItems += 1;
                        CloseAllInteractionUI();
                        break;
                    default:
                        break;
                }
                
            }
        }
    }

    private void OpenLockedDoor()
    {
        if (interactedObject.GetComponent<DoorMovementAnimation>().opened)
        {
            CloseAllInteractionUI();
            return;
        } else if (Input.GetKeyDown(KeyCode.E))
        {
            if (UseItem(properties.itemRequisition.ToString()))
            {
                interactedObject.GetComponent<DoorMovementAnimation>().open = true;
            }
        }
    }

    private void OpenDoor()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

        }
    }

    void ReadText(Texture image)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            paperImage.texture = image;
            paperImage.enabled = !paperImage.enabled;
        }
    }

    void GrabItem()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (properties.itemType.ToString())
            {
                case "None":
                    break;
                case "Gasoline":
                    inv.gasolineGallon += 1;
                    Destroy(interactedObject);
                    break;
                case "Candle":
                    inv.candles += 1;
                    Destroy(interactedObject);
                    break;
                case "Sack":
                    inv.saltSack += 1;
                    Destroy(interactedObject);
                    break;
                case "HouseKey":
                    inv.houseKey += 1;
                    Destroy(interactedObject);
                    break;
                case "StrangeKey":
                    inv.strangeKey += 1;
                    Destroy(interactedObject);
                    break;
                default:
                    break;
            }
            activeInteraction = false;
            CloseAllInteractionUI();
        }
    }

    bool UseItem(string itemName)
    {
        if (itemName == "None")
        {
            return true;
        } else
        if (itemName == "Gasoline" & inv.gasolineGallon > 0)
        {
                inv.gasolineGallon -= 1;
                return true;
        } else
        if (itemName == "Candle" & inv.candles > 0)
        {
                inv.candles -= 1;
                return true;
        } else
        if (itemName == "Sack" & inv.saltSack > 0)
        {
                inv.saltSack -= 1;
                return true;
        } else
        if (itemName == "HouseKey" & inv.houseKey > 0)
        {
                inv.houseKey -= 1;
                return true;
        } else
        if (itemName == "StrangeKey" & inv.strangeKey > 0)
        {
                inv.strangeKey -= 1;
                return true;
        }
        return false;
    }

    void CloseAllInteractionUI()
    {
        hint.enabled = false;
        paperImage.enabled = false;
    }


}

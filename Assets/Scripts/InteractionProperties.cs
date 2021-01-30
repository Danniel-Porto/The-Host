using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionProperties : MonoBehaviour
{
    public enum Type { Paper, Item, Door, LockedDoor, NoHint, ItemPlacement };
    public enum item { None, Gasoline, Candle, Sack, HouseKey, StrangeKey };

    [Header("On UI Hint")]
    public Type interactionType;

    [Header("Properties")]
    public Texture paperTexture;
    public item itemType;
    public item itemRequisition;
}

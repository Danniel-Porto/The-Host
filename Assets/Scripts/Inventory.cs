using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int gasolineGallon, candles, saltSack, houseKey, strangeKey, placedItems;

    [SerializeField] GameObject inventoryUI;
    GameObject gasolineGallonUI, candleUI, saltSackUI, houseKeyUI, strangeKeyUI;

    private void Start()
    {
        gasolineGallon = candles = saltSack = houseKey = strangeKey = 0;
        gasolineGallonUI = inventoryUI.transform.Find("GasolineGallonUI").gameObject;
        candleUI = inventoryUI.transform.Find("CandlesUI").gameObject;
        saltSackUI = inventoryUI.transform.Find("SackUI").gameObject;
        houseKeyUI = inventoryUI.transform.Find("HouseKeyUI").gameObject;
        strangeKeyUI = inventoryUI.transform.Find("StrangeKeyUI").gameObject;
    }


    private void Update()
    {
        UpdateInventory();
        if (placedItems == 7)
        {
            GameObject.FindGameObjectWithTag("Ritual").GetComponent<RitualSequence>().Sequence();
            placedItems = 0;
        }
    }

    void UpdateInventory()
    {
        gasolineGallonUI.SetActive(gasolineGallon > 0);
        candleUI.SetActive(candles > 0);
        candleUI.transform.Find("CandleCounter").gameObject.GetComponent<AutoTextCounter>().value = candles;
        saltSackUI.SetActive(saltSack > 0);
        houseKeyUI.SetActive(houseKey > 0);
        strangeKeyUI.SetActive(strangeKey > 0);

    }
}

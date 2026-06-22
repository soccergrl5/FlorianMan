using System;
using FlorianMan.Inventory;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class InventoryActivated : MonoBehaviour
{
    private TimeAffected _timeAffected;

    public void Start()
    {
        _timeAffected = GetComponent<TimeAffected>();
    }

    void OnMouseDown()
    {
        //Needs to be given to Cogs, Butter, and the vinyls
        switch (this.gameObject.name)
        {
            case "Cogwheel1":InventoryManager.Instance.AddItem(InventoryItems.Cogwheel); break;
            case "Cogwheel2": InventoryManager.Instance.AddItem(InventoryItems.Cogwheel); break;
            case "Cogwheel3": InventoryManager.Instance.AddItem(InventoryItems.Cogwheel); break;
            case "Butter": InventoryManager.Instance.AddItem(InventoryItems.Butter); break;
            case "MusicVinyl": InventoryManager.Instance.AddItem(InventoryItems.MusicVinylRecord); break;
            case "HintVinyl": InventoryManager.Instance.AddItem(InventoryItems.HintVinylRecord); break;
            default: Debug.Log("Invalid Inventory Item in InventoryActivated"); break;
        }
        gameObject.SetActive(false);
           
    }
}

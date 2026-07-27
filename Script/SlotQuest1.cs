using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SlotQuest1 : MonoBehaviour
{

    //ITEM DATA
    [Header("ITEM DATA")]
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFilled;

    private string namaitem = "carbon";

    //ITEMSLOT

    [Header("ITEM SLOT")]
    [SerializeField] private Image itemImage;
    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        Debug.Log("item sudah di add ke dalam slot " + itemName);
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        isFilled = true;
        if (itemSprite)
        {

            Debug.Log("itemSprite is not null");
            // Add your logic here if itemSprite is not null
        }
        else
        {

            Debug.Log("itemSprite is null");
            // Add your logic here if itemSprite is null
        }
        if (MatchItem())
        {
            Debug.Log(MatchItem());
            Debug.Log("Nama item di ItemSlotQuest cocok dengan nama item di SlotQuest.");
        }
        else
        {
            Debug.Log(MatchItem());

            Debug.Log("Nama item di ItemSlotQuest tidak cocok dengan nama item di SlotQuest.");
            Debug.Log("Karena namaitem " + namaitem + "tidak sama dengan itemName " + itemName);
        }


    }



    public bool MatchItem()
    {
        Debug.Log("itemName: " + itemName);
        Debug.Log("namaitem: " + namaitem);
        return itemName == namaitem;

    }


    public bool IsEmpty()
    {
        return !isFilled;
    }


    // Method untuk mencocokan item di slot dengan item yang diinginkan



}



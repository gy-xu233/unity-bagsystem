using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagItem
{
    public enum ItemTypes
    {
        UnKnown = -1,
        Book,
        Equip,
        Consumables
    }

    public string ItemName;
    public int ItemID;
    public string ItemIcon;
    public int ItemCount;
    public ItemTypes ItemType = ItemTypes.UnKnown;
    public BagItem(int ItemID,string ItemName, string ItemIcon, int ItemCount, int ItemType)
    {
        this.ItemID = ItemID;
        this.ItemName = ItemName;
        this.ItemIcon = ItemIcon;
        this.ItemCount = ItemCount;
        switch (ItemType)
        {
            case 0:
                this.ItemType = ItemTypes.Book;
                break;
            case 1:
                this.ItemType = ItemTypes.Equip;
                break;
            case 2:
                this.ItemType = ItemTypes.Consumables;
                break;
        }
    }

}

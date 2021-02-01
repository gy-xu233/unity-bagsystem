using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagInformationControlScript : MonoBehaviour
{
    public Text ItemName;
    public Text ItemDescribe;
    public Button AbandonButton;
    public Button EquipButton;
    public Button ConsumableButton;
    public BagContentControlScripts BagContentControl;
    public BagNumInputControlScript NumInputControlScript;

    private int ItemCount;
    private int ItemIndex;
    void Start()
    {
        
    }
    private void OnEnable()
    {
        this.ClearInformationPanel();
    }
    public void ClearInformationPanel()
    {
        ItemName.gameObject.SetActive(false);
        ItemDescribe.gameObject.SetActive(false);
        AbandonButton.gameObject.SetActive(false);
        EquipButton.gameObject.SetActive(false);
        ConsumableButton.gameObject.SetActive(false);
    }

    public void SetInformationPanel(BagItem bagItem,int itemIndex)
    {
        this.ItemName.text = bagItem.ItemName;
        this.ItemCount = bagItem.ItemCount;
        this.ItemIndex = itemIndex;
        this.ItemDescribe.text = itemIndex.ToString();
        this.ItemDescribe.gameObject.SetActive(true);
        this.ItemName.gameObject.SetActive(true);

        if(bagItem.ItemType != BagItem.ItemTypes.UnKnown)
        {
            AbandonButton.gameObject.SetActive(true);
            AbandonButton.onClick.RemoveAllListeners();
            if (ItemCount > 1)
            {
                AbandonButton.onClick.AddListener(() => NumInputControlScript.OpenBagItemNumInputField(ItemCount,
                BagNumInputControlScript.ConsumableOrAbandon.Abandon));
            }
            else if (ItemCount == 1)
            {
                AbandonButton.onClick.AddListener(() => this.AbandonButtonClick(1));
            }
        }
        else AbandonButton.gameObject.SetActive(false);

        if (bagItem.ItemType == BagItem.ItemTypes.Equip||bagItem.ItemType == BagItem.ItemTypes.Book)
        {
            EquipButton.gameObject.SetActive(true);
            EquipButton.onClick.RemoveAllListeners();
            EquipButton.onClick.AddListener(() => this.EquipButtonClick());
        }
        else EquipButton.gameObject.SetActive(false);

        if (bagItem.ItemType == BagItem.ItemTypes.Consumables)
        {
            ConsumableButton.gameObject.SetActive(true);
            ConsumableButton.onClick.RemoveAllListeners();
            if(ItemCount > 1)
            {
                ConsumableButton.onClick.AddListener(() => NumInputControlScript.OpenBagItemNumInputField(ItemCount,
                BagNumInputControlScript.ConsumableOrAbandon.Consumable));
            }
            else if(ItemCount == 1)
            {
                EquipButton.onClick.AddListener(() => this.ConsumableButtonClick(1));
            }
        }
        else ConsumableButton.gameObject.SetActive(false);
        
    }
    public void AbandonButtonClick(int num)
    {
        this.BagContentControl.AbandonButtonClick(ItemIndex, num);
    }
    private void EquipButtonClick()
    {
        this.BagContentControl.EquipButtonClick(ItemIndex);
    }
    public void ConsumableButtonClick(int num)
    {
        this.BagContentControl.ConsumableButtonClick(ItemIndex, num);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

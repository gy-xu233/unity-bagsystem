using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class BagContentControlScripts : MonoBehaviour
{
    private JsonData AllItemJsonData;
    public List<BagItem> AllItemData;
    public List<GameObject> AllItemObject;
    public Transform TempItem;
    public ScrollRect TempScrollRect;
    public BagInformationControlScript InformationPanel;
    void Start()
    {

    }
    private void Awake()
    {
        if (AllItemData == null)
        {
            this.AllItemData = new List<BagItem>();
        }
        AllItemJsonData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/config/AllItems.json", Encoding.GetEncoding("GB2312")));
        DecodeJson();
        if(AllItemObject == null)
        {
            this.AllItemObject = new List<GameObject>();
        }
    }
    private void OnEnable()
    {
        
    }
    public void RefreshBagContent(BagItem.ItemTypes ContentType)
    {
        int index = 0;
        for(int j = 0; j < AllItemData.Count;j++)
        {
            if (AllItemData[j].ItemType == ContentType)
            {
                GameObject go;
                if (index < AllItemObject.Count)
                {
                    go = AllItemObject[index];
                }
                else
                {
                    go = GameObject.Instantiate(this.TempItem.gameObject, this.TempScrollRect.content);
                    AllItemObject.Add(go);
                }

                BagSetItem bagSetItem = go.GetComponent<BagSetItem>();
                Button ItemButton = bagSetItem.ItemButton;
                ItemButton.onClick.RemoveAllListeners();
                int ItemIndex = j;
                ItemButton.onClick.AddListener(()=>this.SetInformationPanel(ItemIndex));
                bagSetItem.SetItem(AllItemData[j]);
                index++;
            }
            if (index < AllItemObject.Count)
            {
                for (int i = index; i < AllItemObject.Count; i++) AllItemObject[i].SetActive(false);
            }
        }
        
    }

    private void SetInformationPanel(int ItemIndex)
    {
        this.InformationPanel.SetInformationPanel(AllItemData[ItemIndex], ItemIndex);
    }

    public void RefreshBagUnknown(Toggle T)
    {
        if(T.isOn)
        {
            RefreshBagContent(BagItem.ItemTypes.UnKnown);
        }
    }

    public void RefreshBagEquip(Toggle T)
    {
        if (T.isOn)
        {
            RefreshBagContent(BagItem.ItemTypes.Equip);
        }
    }
    public void RefreshBagBook(Toggle T)
    {
        if (T.isOn)
        {
            RefreshBagContent(BagItem.ItemTypes.Book);
        }
    }
    public void RefreshBagConsumable(Toggle T)
    {
        if (T.isOn)
        {
            RefreshBagContent(BagItem.ItemTypes.Consumables);
        }
    }

    public void ConsumableButtonClick(int ItemIndex, int num)
    {
        Debug.Log(AllItemData[ItemIndex].ItemName + "被使用");
    }
    public void AbandonButtonClick(int ItemIndex, int num)
    {
        Debug.Log(AllItemData[ItemIndex].ItemName + "被丢弃");

    }
    public void EquipButtonClick(int ItemIndex)
    {
        Debug.Log(AllItemData[ItemIndex].ItemName + "被装备");

    }

    private void DecodeJson()
    {
        for (int i = 0; i < this.AllItemJsonData.Count; i++)
        {
            int itemID = (int)this.AllItemJsonData[i][0];
            string itemName = this.AllItemJsonData[i][1].ToString();
            string itemIcon = this.AllItemJsonData[i][2].ToString();
            int itemCount = (int)this.AllItemJsonData[i][3];
            int itemType = (int)this.AllItemJsonData[i][4];
            BagItem item = new BagItem(itemID, itemName, itemIcon, itemCount, itemType);
            AllItemData.Add(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

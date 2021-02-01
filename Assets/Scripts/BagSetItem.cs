using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BagSetItem : MonoBehaviour
{
    // Start is called before the first frame update
    public Image ItemIcon;
    public Image ItemBg;
    public Text ItemCount;
    public Button ItemButton;
    void Start()
    {
        
    }
    public void SetItem(BagItem bagItem)
    {
        this.ItemIcon.sprite = Resources.Load<Sprite>("Texture/Items/" + bagItem.ItemIcon);
        this.ItemCount.text = bagItem.ItemCount.ToString();
        this.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

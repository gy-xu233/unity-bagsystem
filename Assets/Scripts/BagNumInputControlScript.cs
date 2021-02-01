using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagNumInputControlScript : MonoBehaviour
{
    public Image UImask;
    public Button UpButton;
    public Image UpImage;
    public InputField NumInput;
    public BagInformationControlScript bagInformationControlScript;
    private int ItemMaxCount;
    private int IfUpOrDown;   //-1:down, 1:up, 0:none
    public enum ConsumableOrAbandon
    {
        Consumable,
        Abandon
    }
    public ConsumableOrAbandon WhoOpenMe;   //0:consumable,  1:Abandon
    void Start()
    {
        IfUpOrDown = 0;
    }

    public void OpenBagItemNumInputField(int ItemCount,ConsumableOrAbandon ConsumableOrAbandon) //0:consumable,  1:Abandon
    {
        this.ItemMaxCount = ItemCount;
        this.WhoOpenMe = ConsumableOrAbandon;
        this.NumInput.placeholder.GetComponent<Text>().text = "0~" + ItemCount.ToString();
        this.NumInput.text = "0";
        this.gameObject.SetActive(true);
    }

    public void ConfirmButtonClick()
    {
        if(this.NumInput.text != "" && this.NumInput.text != "-")
        {
            int num = System.Int32.Parse(this.NumInput.text);
            switch (this.WhoOpenMe)
            {
                case ConsumableOrAbandon.Abandon:
                    this.bagInformationControlScript.AbandonButtonClick(num);
                    break;
                case ConsumableOrAbandon.Consumable:
                    this.bagInformationControlScript.ConsumableButtonClick(num);
                    break;
            }  
        }
        this.CloseBagItemInput();
    }

    public void CloseBagItemInput()
    {
        this.UImask.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void UpButtonClick()
    {
        this.IfUpOrDown = 1;
    }
    public void DownButtonClick()
    {
        this.IfUpOrDown = -1;
    }

    private void OnEnable()
    {
        this.UImask.gameObject.SetActive(true);
        this.NumInput.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        int nowNum = IfUpOrDown;
        string InputString = this.NumInput.text;
        if (InputString != ""&& InputString != "-")
            nowNum += System.Int32.Parse(this.NumInput.text);
        if (IfUpOrDown == 0 && InputString == "")
            this.NumInput.text = "";
        else if (nowNum < 0)
            this.NumInput.text = "0";
        else if (nowNum > this.ItemMaxCount)
            this.NumInput.text = ItemMaxCount.ToString();
        else
            this.NumInput.text = nowNum.ToString();
        IfUpOrDown = 0;
    }
}

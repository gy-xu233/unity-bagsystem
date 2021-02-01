using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Text;

public class BagPanelControlScript : MonoBehaviour
{
    public void BagPanelChangeActive()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
}

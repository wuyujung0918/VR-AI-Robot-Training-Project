using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnGotoItemCtrl : MonoBehaviour
{
    public BtnGotoItemSetCtrl BtnGotoItemSet;
    public Button thisButton;
    public int btnId;
    // Start is called before the first frame update
    public void Init(BtnGotoItemSetCtrl bgis, int id)
    {
        BtnGotoItemSet = bgis;
        thisButton = this.transform.GetComponent<Button>();
        thisButton.onClick.AddListener(WhenClick);
        btnId = id;
    }

    void WhenClick()
    {
        BtnGotoItemSet.EventGotoItem(btnId);
    }
}

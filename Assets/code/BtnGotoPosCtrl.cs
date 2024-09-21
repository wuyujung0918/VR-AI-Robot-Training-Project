using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnGotoPosCtrl : MonoBehaviour
{
    public MainCtrl mCtrl;
    public Button thisButton;
    // Start is called before the first frame update
    public void Init(MainCtrl m)
    {
        mCtrl = m;
        thisButton = this.transform.GetComponent<Button>();
        thisButton.onClick.AddListener(WhenClick);
    }

    void WhenClick()
    {
        mCtrl.EventGotoPos();
    }


}

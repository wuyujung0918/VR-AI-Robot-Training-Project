using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnGotoItemSetCtrl : MonoBehaviour
{
    public MainCtrl mCtrl;
    public BtnGotoItemCtrl[] buttonArr;
    
    // Start is called before the first frame update
    public void Init(MainCtrl m)
    {
        mCtrl = m;
        buttonArr = new BtnGotoItemCtrl[6];
        for (int i=0;i<=5;i++) 
        {
            GameObject btnGo = this.transform.Find("BtnGotoItem" + i).gameObject;
            buttonArr[i] = btnGo.AddComponent<BtnGotoItemCtrl>();
            buttonArr[i].Init(this,i);
        }

    }

    public void EventGotoItem(int btnId) 
    {
        mCtrl.GotoPickItem(btnId);


    }
}

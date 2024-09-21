using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndNoteTxtInput : MonoBehaviour
{
    public MainCtrl mCtrl;
    public int BtnId;
    public InputField DegreeTxtBox;
    // Start is called before the first frame update
    public void Init(MainCtrl m)
    {
        mCtrl = m;
        DegreeTxtBox = this.transform.Find("InputField").GetComponent<InputField>();
        DegreeTxtBox.onEndEdit.AddListener(TxtInputEventEnd);
    }

    public void SetValue(float val) 
    {
        DegreeTxtBox.text = val.ToString("0.00");


    }
    public float GetValue() 
    {
        try 
        {
            return float.Parse(DegreeTxtBox.text);
        }
        catch (Exception e)
        {
            DegreeTxtBox.text = "0";
            return 0;

        }

        


    }

    void TxtInputEventEnd(string str)
    {
        try
        {
            float value = float.Parse(str);
            Debug.Log(BtnId + "value=" + value);
            mCtrl.UpdateEndNoteDegree(BtnId, value);
        }
        catch (Exception e)
        {
            DegreeTxtBox.text = "";

        }

    }
}

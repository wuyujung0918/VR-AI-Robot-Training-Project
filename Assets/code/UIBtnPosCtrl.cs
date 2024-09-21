using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBtnPosCtrl : MonoBehaviour
{
    public MainCtrl mCtrl;
    public Button BtnPosA;

    // Start is called before the first frame update
    public void Init(MainCtrl m)
    {
        mCtrl = m;
        BtnPosA = this.transform.Find("ButtonPosA").GetComponent<Button>();
        BtnPosA.onClick.AddListener(TaskOnClickPosA);
    }

    public void TaskOnClickPosA() 
    {
        float[] degArr = { 0, 60.99f, 0, -76.69f, -95.29f, 0 };

        for(int i=0;i<= degArr.Length; i++)
        {
            float deg = degArr[i];
            mCtrl.BoneDegreeTxtBoxArr[i].SetDegree(deg);
        }

    }



}

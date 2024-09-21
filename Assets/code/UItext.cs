using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UItext : MonoBehaviour
{
    public MainCtrl mCtrl;
    public int btnId;
    public Slider SliderBar;
    public Button BtnLeft, BtnRight, ZeroBt;
    public InputField DegreeTxt;
    public float degreeBuf;
    public float MaxBuf;
    public float MinBuf;

    public bool ChangeFlag;
    public float LastChangeTime;


    // Start is called before the first frame update
    
    public void Init(MainCtrl m)
    {
        mCtrl = m;
        //degreeBuf = 180;
        BtnLeft.onClick.AddListener(TaskOnClickLeft);
        BtnRight.onClick.AddListener(TaskOnClickRight);
        ZeroBt.onClick.AddListener(ReturnToZero);
        DegreeTxt.onEndEdit.AddListener(TxtInputEventEnd);
        SliderBar.onValueChanged.AddListener(BarInputEventEnd);
        UpdateDegree();
    }

    void ReturnToZero()
    {
        Debug.Log("Zero!");
        degreeBuf = 0;
        
        UpdateDegree();
    }

    void TaskOnClickLeft()
    {
        Debug.Log("L!");
        if(degreeBuf < MinBuf) 
        {
            degreeBuf = MinBuf;
        }
        else
        {
            degreeBuf -= 1;
        }
        
        UpdateDegree();
    }

    void TaskOnClickRight()
    {
        Debug.Log("R!");
        if (degreeBuf > MaxBuf)
        {
            degreeBuf = MaxBuf;
        }
        else
        {
            degreeBuf += 1;
        }
       
        UpdateDegree();
    }

    void TxtInputEventEnd(string str)
    {
        Debug.Log("str="+str);
        degreeBuf = float.Parse(str);
        UpdateDegree();
    }

    void BarInputEventEnd(float num) {
        degreeBuf = num * 360f;
        UpdateDegree();
    }

    public void SetDegree(float d)
    {
        degreeBuf = d;
        UpdateDegree();
    }

    public void UpdateDegree()
    {
        ChangeFlag = true;
        LastChangeTime = Time.time;//獲取自遊戲開始以來經過的時間
        DegreeTxt.text = degreeBuf.ToString("0.00");//把角度換算成字串丟入文字格
        SliderBar.value = degreeBuf/ 360f;//SliderBar.value = degreeBuf/ 360f;//把她/360這樣就會0~1


    }

    // Update is called once per frame
    void Update()
    {
        if(ChangeFlag && (LastChangeTime+0.3f)<Time.time)
        {
            ChangeFlag = false;
            mCtrl.GiveDegree(btnId, degreeBuf);
        }
    }


}

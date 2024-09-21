using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBoneCtrl : MonoBehaviour
{
    public Vector3 TargetAngle;//目標旋轉角度
    public Vector3 RotDegreeAll;//累計的旋轉角度
    public bool RotateFlag;
    public float AngleSpeedPerSec;
    public bool rotFlagX,rotFlagY,rotFlagZ;//轉軸執行中不可切換，turn on only one of them
    public float gapLast = 0;//上一畫格的旋轉角度
    public bool isBone8;
    public bool isBone6;
    public bool isBone2;

    // Start is called before the first frame update
    public void Init()
    {
        TargetAngle = this.transform.localRotation.eulerAngles;
        RotDegreeAll = this.transform.localRotation.eulerAngles;
        AngleSpeedPerSec = 30f;
    }

    public void SetTargetDegree(float deg) 
    {
        deg %= 360;
        RotateFlag = true;
        if (rotFlagX)
        {
            TargetAngle.x = deg;
        }
        else if (rotFlagY)
        {
            TargetAngle.y = deg;
        }
        else if (rotFlagZ)
        {
            TargetAngle.z = deg;
        }

    }

    public void RotateBoneByDegree(float deg)
    {
        RotateFlag = true;
        if (rotFlagX){
            TargetAngle.x += deg;
        }
        else if(rotFlagY){
            TargetAngle.y += deg;
        }
        else if(rotFlagZ){
            TargetAngle.z += deg;
        }
    }

    public void RotateRight()
    {
        this.RotateBoneByDegree(1);
    }
    public void RotateLeft()
    {
        this.RotateBoneByDegree(-1);
    }

    // Update is called once per frame
    void Update()
    {
        if (RotateFlag)
        {
            if (isBone8 == true)
            {
                RotateV08();
            }
            else if (isBone6 == true)
            {
                RotateV06();
            }
            else if(isBone2 == true)
            {
                RotateV02();
            }
            else
            {
                RotateV01();
            }
        }
    }

    public void RotateV01()
    {
        float gap = Time.deltaTime * AngleSpeedPerSec;
        if (rotFlagX)
        {
            if (TargetAngle.x < RotDegreeAll.x)//?
            {
                gap *= -1;//?
            }
            this.transform.Rotate(gap, 0, 0, Space.Self);
            RotDegreeAll.x += gap;
        }
        if (rotFlagY)
        {
            if (TargetAngle.y < RotDegreeAll.y)
            {
                gap *= -1;
            }
            this.transform.Rotate(0, gap, 0, Space.Self);
            RotDegreeAll.y += gap;
        }
        if (rotFlagZ)
        {
            if (TargetAngle.z < RotDegreeAll.z)
            {
                gap *= -1;
            }
            this.transform.Rotate(0, 0, gap, Space.Self);
            RotDegreeAll.z += gap;
        }

        if (rotFlagX || rotFlagY || rotFlagZ)
        {
            //arrive at the target degree
            if ((gap > 0 && gapLast < 0) || (gapLast < 0 && gap > 0) || gap == 0)
            {
                RotateFlag = false;
            }
            gapLast = gap;
        }


    }

    public void RotateV08()
    {
        //only for z 
        float gap = Time.deltaTime * AngleSpeedPerSec;
        if (rotFlagZ)
        {//-205 ~ +36

            float offsetDeg = 205;
            float tarDegZ = (TargetAngle.z + offsetDeg) % 360;//0 ~ 241
            float nowDegZ = (RotDegreeAll.z + offsetDeg) % 360;//0 ~ 241

            if (241 <= tarDegZ)
            {
                tarDegZ = 241;
            }

            if (tarDegZ < nowDegZ)
            { //減角度
                gap *= -1;
            }
            else
            {//加角度 
                gap *= 1;
            }

            this.transform.Rotate(0, 0, gap, Space.Self);
            RotDegreeAll.z += gap;

            //arrive at the target degree
            if ((gap > 0 && gapLast < 0) || (gapLast < 0 && gap > 0) || gap == 0)
            {
                Debug.Log("DB0");
                RotateFlag = false;
            }
            if (nowDegZ <= 0 || 241 <= nowDegZ)
            {
                Debug.Log("DB1, nowDegZ" + nowDegZ);
               
                RotateFlag = false;
            }

            gapLast = gap;
           
        }
       
    }

    public void RotateV06()
    {
        //only for z 
        float gap = Time.deltaTime * AngleSpeedPerSec;
        if (rotFlagY)
        {//-160 ~ +180

            float offsetDeg = 160;
            float tarDegY = (TargetAngle.y + offsetDeg) % 360;//0 ~340
            float nowDegY = (RotDegreeAll.y + offsetDeg) % 360;//0 ~340

            if (340 <= tarDegY)
            {
                tarDegY = 340;
            }

            if (tarDegY < nowDegY)
            { //減角度
                gap *= -1;
            }
            else
            {//加角度 
                gap *= 1;
            }

            this.transform.Rotate(0, -gap, 0,  Space.Self);
            RotDegreeAll.y += gap;

            //arrive at the target degree
            if ((gap > 0 && gapLast < 0) || (gapLast < 0 && gap > 0) || gap == 0)
            {
                Debug.Log("DB0");
                RotateFlag = false;
            }
            if (nowDegY <= 0 || 340 <= nowDegY)
            {
                Debug.Log("DB1, nowDegY" + nowDegY);
                RotateFlag = false;
            }

            gapLast = gap;
        }

    }

    public void RotateV02()
    {
        //only for z 
        float gap = Time.deltaTime * AngleSpeedPerSec;
        if (rotFlagZ)
        {//-40 ~ +70

            float offsetDeg = 40;
            float tarDegZ = (TargetAngle.z + offsetDeg) % 360;//0 ~ 110
            float nowDegZ = (RotDegreeAll.z + offsetDeg) % 360;//0 ~ 110

            if (110 <= tarDegZ)
            {
                tarDegZ = 110;
            }



            if (tarDegZ < nowDegZ)
            { //減角度
                gap *= -1;
            }
            else
            {//加角度 
                gap *= 1;
            }

            this.transform.Rotate(0, 0, gap, Space.Self);
            RotDegreeAll.z += gap;

            //arrive at the target degree
            if ((gap > 0 && gapLast < 0) || (gapLast < 0 && gap > 0) || gap == 0)
            {
                Debug.Log("DB0");
                RotateFlag = false;
            }
            if (nowDegZ <= 0 || 110 <= nowDegZ)
            {
                Debug.Log("DB1, nowDegZ" + nowDegZ);
                RotateFlag = false;
            }

            gapLast = gap;
        }

    }
}
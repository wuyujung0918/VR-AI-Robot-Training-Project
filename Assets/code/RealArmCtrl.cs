using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class RealArmCtrl : MonoBehaviour
{
    public bool RealArmExist;
    public SerialPort port;
    public int[] ArmDegreeArr;//六軸的參數

    // Start is called before the first frame update
    public void Init()
    {
        RealArmExist = false;

        try
        {
            port = new SerialPort("COM3", 115200);
            port.Open();
            RealArmExist = true;
        }
        catch (Exception e)
        {
            //中斷
            return;
        }

        //port = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
        
        Debug.Log("S1");
        StartCoroutine(InitActionShake());
        ArmDegreeArr = new int[6]; //?
    }

    IEnumerator InitActionShake()
    {
        yield return new WaitForSeconds(4);
        this.PortWrite("M21 G90 G01 X0 Y0 Z0 A0 B0 C0 F2000");
        yield return new WaitForSeconds(1.5f);
        this.PortWrite("M21 G90 G00 X-15.00 Y-10.00 Z-15.00 A0.00 B0.00 C0.00 F2000.00");
        yield return new WaitForSeconds(1.5f);
        this.PortWrite("M21 G90 G01 X0 Y0 Z0 A0 B0 C0 F2000");
    }

    void OnDestroy(){
        port.Close();
    }

    // Update is called once per frame
    void Update() {
    }

    public void GiveDegree(int armBoneLv ,float degree) 
    {
        if (RealArmExist==false) 
        {
            return;
        }


        ArmDegreeArr[armBoneLv] = (int)Mathf.Round(degree);//將度數四捨五入

        string modifiedCommand = "M21 G90 G01 "+
            "X" + ArmDegreeArr[0].ToString() + " "+
            "Y" + ArmDegreeArr[1].ToString() + " "+
            "Z" + ArmDegreeArr[2].ToString() + " "+
            "A" + ArmDegreeArr[3].ToString() + " "+
            "B" + ArmDegreeArr[4].ToString() + " "+
            "C" + ArmDegreeArr[5].ToString() + " "+
            "F2000";
        this.PortWrite(modifiedCommand);
    }

    private void PortWrite(string msg){
        Debug.Log("msg="+msg);
        port.Write(msg);
    }



    /*public void EventClick(int btnId){
        Debug.Log("Real"+btnId);
        if (btnId==1){
            //this.PortWrite("M21 G90 G01 X0 Y0 Z0 A0 B0 C0 F2000");
            Xvalue += 5;
            string modifiedCommand = "M21 G90 G01 X" + Xvalue.ToString() + " Y0 Z0 A0 B0 C0 F2000";
            this.PortWrite(modifiedCommand);// 寫入修改後的指令字符串到port
        }
        else if(btnId==2){
            Xvalue -= 5;
            string modifiedCommand = "M21 G90 G01 X" + Xvalue.ToString() + " Y0 Z0 A0 B0 C0 F2000";
            this.PortWrite(modifiedCommand);// 寫入修改後的指令字符串到port
        }
        if(btnId==11) {
            //Yvalue += 5;

//          下一行是完整的指令可以給六個軸座使用，變數已改好！
            //string modifiedCommand = "M21 G90 G01 X" + Xvalue.ToString() + " Y" + Yvalue.ToString() + " Z" + Zvalue.ToString() +  " A" + Avalue.ToString() + " B" + Avalue.ToString() + " C" + Avalue.ToString() + " F2000";
            //port.Write(modifiedCommand);// 寫入修改後的指令字符串到port
        }

    }*/

    
}

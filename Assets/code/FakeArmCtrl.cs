using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeArmCtrl : MonoBehaviour
{
    //-----------------------
    public ArmBoneCtrl[] ArmBoneArr;



    // Start is called before the first frame update
    public void Init()
    {
        foreach (ArmBoneCtrl bone in ArmBoneArr) {
            bone.Init();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EventClick(int btnId){
        Debug.Log("fake"+btnId);
        if (btnId==1){
            ArmBoneArr[0].RotateLeft();
        }
        else if(btnId==2){
            ArmBoneArr[0].RotateRight();
        }
        if(btnId==11){
            ArmBoneArr[1].RotateLeft();
        }
        else if(btnId==12){
            ArmBoneArr[1].RotateRight();
        }
        else if(btnId==21){
            ArmBoneArr[2].RotateLeft();
        }
        else if(btnId==22){
            ArmBoneArr[2].RotateRight();
        }
        else if (btnId == 31)
        {
            ArmBoneArr[3].RotateLeft();
        }
        else if (btnId == 32)
        {
            ArmBoneArr[3].RotateRight();
        }
        else if (btnId == 41)
        {
            ArmBoneArr[4].RotateLeft();
        }
        else if (btnId == 42)
        {
            ArmBoneArr[4].RotateRight();
        }
        else if (btnId == 51)
        {
            ArmBoneArr[5].RotateLeft();
        }
        else if (btnId == 52)
        {
            ArmBoneArr[5].RotateRight();
        }
    }

    public void GiveDegree(int armBoneLv ,float degree) 
    {
        if (armBoneLv==4) 
        {
            degree *= -1;
        }
        


        ArmBoneArr[armBoneLv].SetTargetDegree(degree);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCtrl : MonoBehaviour
{
    public FakeItemSetCtrl FakeItemSet;
    public BtnGotoPosCtrl BtnGotoPos;
    public BtnGotoItemSetCtrl BtnGotoItemSet;
    public FakeArmCtrl FakeArm;
    public RealArmCtrl RealArm;

    public Vector3 EndNotePos;
    public UIBtnPosCtrl UIBtnPos;
    public UItext[] BoneDegreeTxtBoxArr;
    public EndNoteTxtInput[] EndNoteTxtBoxArr;
    public Transform Canvas;
    public ObjectInfoBuffer ObjInfoBuf;

    // Start is called before the first frame update
    void Start()
    {
        FakeItemSet.Init(this);
        ObjInfoBuf.Init();
        UIBtnPos.Init(this);
        FakeArm.Init();
        //-
        BoneDegreeTxtBoxArr = new UItext[6];
        Canvas = GameObject.Find("Canvas").transform;
        for (int i = 0; i <= 5; i++)
        {
            BoneDegreeTxtBoxArr[i] = Canvas.Find("u" + i).GetComponent<UItext>();
            BoneDegreeTxtBoxArr[i].Init(this);
        }
        //-
        EndNoteTxtBoxArr = new EndNoteTxtInput[3];
        EndNoteTxtBoxArr[0] = Canvas.Find("eX").GetComponent<EndNoteTxtInput>();
        EndNoteTxtBoxArr[1] = Canvas.Find("eY").GetComponent<EndNoteTxtInput>();
        EndNoteTxtBoxArr[2] = Canvas.Find("eZ").GetComponent<EndNoteTxtInput>();
        EndNoteTxtBoxArr[0].Init(this);
        EndNoteTxtBoxArr[1].Init(this);
        EndNoteTxtBoxArr[2].Init(this);

        BtnGotoPos.Init(this);
        BtnGotoItemSet.Init(this);
        //-
        RealArm.Init();

    }

    public void GotoPickItem(int btnId)
    {
        MoveableItem mvItem = ObjInfoBuf.GetAttrOfItemId(btnId);
        Vector3 fakePos = FakeItemSet.GroundSpace.Convert2FakeWorldPos(mvItem.pos);
        //Debug.Log(fakePos);

        EndNoteTxtBoxArr[0].SetValue(fakePos.x);
        EndNoteTxtBoxArr[1].SetValue(fakePos.y);
        EndNoteTxtBoxArr[2].SetValue(fakePos.z);
        EventGotoPos();
    }

    public void EventGotoPos()
    {
        Vector3 targetPos = new Vector3();
        targetPos.x = EndNoteTxtBoxArr[0].GetValue();
        targetPos.y = EndNoteTxtBoxArr[1].GetValue();
        targetPos.z = EndNoteTxtBoxArr[2].GetValue();
        Debug.Log(targetPos);
        int[] degreeArr = Inverse.CalcDegree(targetPos);
        for (int i = 0; i <= 5; i++)
        {
            int deg = degreeArr[i];
            UItext BoneDegreeTxtBox = BoneDegreeTxtBoxArr[i];
            BoneDegreeTxtBox.SetDegree(deg);
        }


    }

    public void GiveDegree(int armBoneLv, float degree)
    {
        FakeArm.GiveDegree(armBoneLv, degree);
        RealArm.GiveDegree(armBoneLv, degree);
    }

    public void UpdateEndNoteDegree(int btnId, float val)
    {
        //set xyz value
        if (btnId == 1)
        {
            EndNotePos.x = val;
        }
        else if (btnId == 2)
        {
            EndNotePos.y = val;
        }
        else if (btnId == 3)
        {
            EndNotePos.z = val;
        }

        //convert end note pos to 6 degrees
        int[] degreeArr = Inverse.CalcDegree(EndNotePos);

        for (int i = 0; i <= 5; i++)
        {

            BoneDegreeTxtBoxArr[i].SetDegree(degreeArr[i]);
        }

    }
    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Z)) {
            FakeArm.EventClick(1);
        }
        */
    }

    
}
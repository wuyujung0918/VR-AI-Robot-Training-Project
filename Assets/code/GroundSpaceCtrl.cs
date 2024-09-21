using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpaceCtrl : MonoBehaviour
{
    public MainCtrl mCtrl;
    public Transform PosRef00, PosRefXZ;//x0y0, x31z31
    public Vector3 Pos00;
    public Vector3 PosXZ;//Xµu√‰ Z™¯√‰
    
    public float RatioX, RatioZ;

    public void Init(MainCtrl m)
    {
        mCtrl = m;
        PosRef00 = this.transform.Find("GroundSpacePosRef00");
        PosRefXZ = this.transform.Find("GroundSpacePosRefXZ");
        Pos00 = PosRef00.position;
        PosXZ = PosRefXZ.position;
        RatioX = (PosXZ.x - Pos00.x)/ 31.0f;
        RatioZ = (PosXZ.z - Pos00.z)/ 31.0f;

    }

    public Vector3 Convert2FakeWorldPos(Vector3 realPos) 
    {


        Vector3 fakePos = new Vector3();
        fakePos.x = Pos00.x +(realPos.x * RatioX);
        fakePos.y = Pos00.y;
        fakePos.z = Pos00.z + (realPos.z * RatioZ);
        return fakePos;
    }

}

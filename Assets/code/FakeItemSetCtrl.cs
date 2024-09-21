using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeItemSetCtrl : MonoBehaviour
{
    public MainCtrl mCtrl;
    public GroundSpaceCtrl GroundSpace;
    public FakeItemCtrl FakeItemTemplate;
    public FakeItemCtrl[] FakeItemArr;
    

    public void Init(MainCtrl m)
    {
        mCtrl = m;
        GroundSpace = this.transform.parent.Find("GroundSpace").GetComponent<GroundSpaceCtrl>();
        GroundSpace.Init(m);
        FakeItemTemplate = this.transform.Find("FakeItemTemplate").GetComponent<FakeItemCtrl>();
        FakeItemTemplate.Init();

        FakeItemArr = new FakeItemCtrl[6];
        for (int i=0; i<6; i++) 
        {
            Vector3 pos = FakeItemTemplate.transform.position;
            pos.z -= 1 + (i * 1); 

            Quaternion rot = FakeItemTemplate.transform.rotation;
            FakeItemCtrl fakeItem = Instantiate(FakeItemTemplate, pos, rot);
            fakeItem.StandbyPos = pos;
            fakeItem.transform.parent = this.transform;
            fakeItem.name = "FakeItem" + i;
            fakeItem.SetModel(23);
            FakeItemArr[i] = fakeItem;
        }

        StartCoroutine(DelayAndUpdateFakeItem());
    }

    public void SetFakeItem(MoveableItem mvItem) 
    {
        
        if (mvItem.status == 1)
        {
            FakeItemCtrl fakeItem = FakeItemArr[mvItem.ObjId];
            fakeItem.SetModel(mvItem.featureCode);//11 12 13 21 22 23
            
            fakeItem.transform.position = GroundSpace.Convert2FakeWorldPos(mvItem.pos);

        }
        else 
        {
            FakeItemCtrl fakeItem = FakeItemArr[mvItem.ObjId];
            fakeItem.SetModel(0);
            fakeItem.transform.position = fakeItem.StandbyPos;
        }
    }

    
    void Update()
    {
        
    }

    public IEnumerator DelayAndUpdateFakeItem() 
    {
        for (int i=0;i<mCtrl.ObjInfoBuf.ObjIdArr.Length;i++) 
        {
            MoveableItem mvItem = mCtrl.ObjInfoBuf.GetAttrOfItemId(i);
            SetFakeItem(mvItem);



        }


        yield return new WaitForSeconds(0.2f);
        StartCoroutine(DelayAndUpdateFakeItem());
    }
}

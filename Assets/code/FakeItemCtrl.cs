using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeItemCtrl : MonoBehaviour
{
    public Vector3 StandbyPos;
    public Transform[] ItemModelArr;
    public int[] ItemModelIdArr;
    public void Init()
    {
        ItemModelIdArr = new int[6];
        ItemModelIdArr[0] = 11;
        ItemModelIdArr[1] = 12;
        ItemModelIdArr[2] = 13;
        ItemModelIdArr[3] = 21;
        ItemModelIdArr[4] = 22;
        ItemModelIdArr[5] = 23;


        ItemModelArr = new Transform[24];

        foreach (int i in ItemModelIdArr) 
        {
            ItemModelArr[i] = this.transform.Find("ItemModel"+i);

        }
    }

    public void SetModel(int id) 
    {
        foreach (int i in ItemModelIdArr)
        {
            ItemModelArr[i].gameObject.SetActive(false);
        }

        if (ItemModelArr[id]!=null) 
        {
            ItemModelArr[id].gameObject.SetActive(true);
        }

        
    }

    
}

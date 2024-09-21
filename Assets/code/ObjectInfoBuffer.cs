using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfoBuffer : MonoBehaviour
{
    public int[] ObjIdArr;
    public int[] FeatureCodeArr;
    public float[] PosXArr;
    public float[] PosYArr;
    public float[] PosZArr;
    public int[] StatusArr;
    // Start is called before the first frame update
    public void Init()
    {
        ObjIdArr = new int[6];
        FeatureCodeArr = new int[6];
        PosXArr = new float[6];
        PosYArr = new float[6];
        PosZArr = new float[6];
        StatusArr = new int[6];
    }

    // �ھڭ���M�C��]�wFeatureCode
    /*public void SetFeatureCode(int index, int style, int color)
    {
        style = Mathf.Clamp(style, 0, 1);
        color = Mathf.Clamp(color, 0, 2);
        FeatureCodeArr[index] = style * 10 + color;
    }*/

    // ���ʪ���ç��~�[
    /*public void MoveAndChangeAppearance(int index, Vector3 newPosition, Color newColor, Material styleMaterial)
    {
        // ���ʪ����s����m
        transform.position = newPosition;

        // ������󪺴�V���ե�
        Renderer renderer = GetComponent<Renderer>();

        // �ھڷs�C��������C��
        renderer.material.color = newColor;

        // �ھڷs�y�����������
        renderer.material = styleMaterial;

        // ��sFeatureCode�H�ϬM���
        SetFeatureCode(index, 0, 0);
    }*/



    public MoveableItem GetAttrOfItemId(int btnId) 
    {
        //find the index @ array
        int ind = 0;
        for(int i=0;i< ObjIdArr.Length; i++) 
        {
            if (ObjIdArr[i]==btnId) 
            {
                ind = i;
            }
        }
        //Debug.Log("ind="+ind);
        //get val and pos
        MoveableItem mvItem = new MoveableItem();
        mvItem.ObjId = ObjIdArr[ind];
        mvItem.featureCode = FeatureCodeArr[ind];
        float x = PosXArr[ind];
        float y = PosYArr[ind];
        float z = PosZArr[ind];
        mvItem.pos = new Vector3(x, y, z);
        mvItem.status = StatusArr[ind];
        return mvItem;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

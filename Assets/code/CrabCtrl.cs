using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrabCtrl : MonoBehaviour
{
    public Button pickupButton;
    public Transform crabTransform; // ���l�� Transform
    public float moveSpeed = 5f; // ���ʳt��
   
    

    private bool isBeingMoved = false;
    private GameObject triggeredObject;

    private void Start()
    {
        // �K�[���s�I���ƥ�
        pickupButton.onClick.AddListener(Pickup);
    }

    void Update()
    {
        if (isBeingMoved && triggeredObject != null)
        {
            // �ϥ� Lerp ��k���Ʋ��ʪ����쪫�骺��m
            triggeredObject.transform.position = Vector3.Lerp(triggeredObject.transform.position, transform.position, Time.deltaTime * moveSpeed);
            // �ϥ� Slerp ��k���Ʊ��ફ���쪫�骺����
            triggeredObject.transform.rotation = Quaternion.Slerp(triggeredObject.transform.rotation, transform.rotation, Time.deltaTime * moveSpeed);

            // �b�@�q�ɶ���۰ʩ�U����
            /*timeBeforeRelease -= Time.deltaTime;
            if (timeBeforeRelease <= 0f)
            {
                PutDownObject();
            }*/
        }
        
       
    }

    // ����I���L�����Ĳ�o
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�I��F");
        

        if (other.CompareTag("TriggerTag"))
        {
            triggeredObject = other.gameObject;
            // �ҥΪ���
            //triggeredObject.SetActive(true);
            // �NĲ�o�����骺��m�]�m���쪫�骺��m
            //triggeredObject.transform.position = transform.position;
            // ��Ĳ�I��Tag:TriggerTag��o�Ӫ���N�|��ۭ쪫�鲾��
            isBeingMoved = true;

        }
        else if (other.CompareTag("Plane"))
        {
            // ��U����
            PutDownObject();
        }
    }

    // �B�����骺���
    private void Pickup()
    {

        // �b�o�̩�m�B�����骺�N�X�A�Ҧp�N����]�����a���l����
        // �A�i�H�ϥ� transform.parent = playerTransform; �������N�X
        Debug.Log("Object picked up!");

        // �ҥΰl�H
        isBeingMoved = true;
    }

    private void PutDownObject()
    {

        isBeingMoved = false;
        /*// �N�����b�쪫�骺���U��A�����q�i�H�ھڻݨD�վ�
        float yOffset = -1.0f; // ��������
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
        triggeredObject.transform.position = newPosition;*/

        // �N���骺���ਤ�׳]�m���쪫�骺���ਤ��
        //triggeredObject.transform.rotation = transform.rotation;
    }


    // �N���󥭷Ʋ��ʨ�ؼЦ�m
    /* void MoveObjectTowardsTarget()
     {
         // �ϥ�Lerp��ƹ�{���Ʋ���
         transform.position = Vector3.Lerp(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

         // �ˬd�O�_�w�g����ؼЦ�m�A�i�H�ھڹ�ڱ��p�վ��H��
         if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
         {
             // ����ʡA��U����
             isBeingMoved = false;
             Debug.Log("����w�g��F�ؼЦ�m");
         }
     }*/
}

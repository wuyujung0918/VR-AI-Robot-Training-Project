using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrabUICtrl : MonoBehaviour
{
    public Button BtnBlow, BtnClose, BtnVomit;
    
    public float moveSpeed = 5f; // ���ʳt��

    private bool isObjectPickedUp = false;
    private GameObject triggeredObject;
    public bool OverlapFlag = false;

    // Start is called before the first frame update
    private void Start()
    {
        
        BtnBlow.onClick.AddListener(TaskOnClickBlow);
        BtnClose.onClick.AddListener(TaskOnClickClose);
        BtnVomit.onClick.AddListener(TaskOnClickVomit);
       
    }
                  
     
    void TaskOnClickBlow()
    {
        Debug.Log("Blow");

        if (isObjectPickedUp && triggeredObject != null)
        {
            Rigidbody rb = triggeredObject.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;
        }
        // �N�����U
        PutDownObject();
    }

    void TaskOnClickClose()
    {
        Debug.Log("Close");

        /*if (isObjectPickedUp && triggeredObject != null)
        {
            Rigidbody rb = triggeredObject.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;
        }
        // �N�����U
        PutDownObject();*/
    }

    void TaskOnClickVomit()
    {
        
        Debug.Log("Vomit");

        //�S�����|�N���_
        if (OverlapFlag==false) 
        {
            return;
        }

        // �}�l����Ĳ�o���{��
        StartCoroutine(TriggerDelayed(1.3f));

    }

    IEnumerator TriggerDelayed(float delayTime)
    {
        // ���ݫ��w������ɶ�
        yield return new WaitForSeconds(delayTime);

        //��_
        Debug.Log("Action V1!!!!!");
        isObjectPickedUp = true;

        // �ˬd�O�_�w�g�������B�s�bĲ�o������
        /*if (isObjectPickedUp && triggeredObject != null)
        {
            // ���Ĳ�o OnTriggerEnter ��k�A��������i�JĲ�o�ϰ�
            //OnTriggerEnter(triggeredObject.GetComponent<Collider>());
        }*/
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("���i�h");
        if (other.CompareTag("TriggerTag"))
        {
            triggeredObject = other.gameObject;
            OverlapFlag = true;//�аO���|��
        }
        /*else
        {
            isObjectPickedUp = false;
        }*/
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("�]��");
        if (other.CompareTag("TriggerTag"))
        {
            triggeredObject = null;
            OverlapFlag = false;//�аO�����|
        }
    }


    private void holdObject() 
    {

        
    }
    

    void CheckTrigger()
    {
        if (isObjectPickedUp && triggeredObject != null)
        {
            
            // �ᵲ Rigidbody ����M��m
            triggeredObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            // �ϥ� Lerp ��k���Ʋ��ʪ����쪫�骺��m
            triggeredObject.transform.position = Vector3.Lerp(triggeredObject.transform.position, transform.position, Time.deltaTime * moveSpeed);
            // �ϥ� Slerp ��k���Ʊ��ફ���쪫�骺����
            triggeredObject.transform.rotation = Quaternion.Slerp(triggeredObject.transform.rotation, transform.rotation, Time.deltaTime * moveSpeed);

        }
    }

    

    void PutDownObject()
    {
        // �N�����U
        if (triggeredObject != null)
        {
            //triggeredObject.SetActive(false);
            triggeredObject = null;
        }

        isObjectPickedUp = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isObjectPickedUp)
        {
            CheckTrigger();
        }
       

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrabUICtrl : MonoBehaviour
{
    public Button BtnBlow, BtnClose, BtnVomit;
    
    public float moveSpeed = 5f; // 移動速度

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
        // 將物體放下
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
        // 將物體放下
        PutDownObject();*/
    }

    void TaskOnClickVomit()
    {
        
        Debug.Log("Vomit");

        //沒有重疊就中斷
        if (OverlapFlag==false) 
        {
            return;
        }

        // 開始延遲觸發的程序
        StartCoroutine(TriggerDelayed(1.3f));

    }

    IEnumerator TriggerDelayed(float delayTime)
    {
        // 等待指定的延遲時間
        yield return new WaitForSeconds(delayTime);

        //抓起
        Debug.Log("Action V1!!!!!");
        isObjectPickedUp = true;

        // 檢查是否已經抓取物體且存在觸發的物體
        /*if (isObjectPickedUp && triggeredObject != null)
        {
            // 手動觸發 OnTriggerEnter 方法，模擬物體進入觸發區域
            //OnTriggerEnter(triggeredObject.GetComponent<Collider>());
        }*/
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("撞進去");
        if (other.CompareTag("TriggerTag"))
        {
            triggeredObject = other.gameObject;
            OverlapFlag = true;//標記重疊中
        }
        /*else
        {
            isObjectPickedUp = false;
        }*/
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("跑掉");
        if (other.CompareTag("TriggerTag"))
        {
            triggeredObject = null;
            OverlapFlag = false;//標記不重疊
        }
    }


    private void holdObject() 
    {

        
    }
    

    void CheckTrigger()
    {
        if (isObjectPickedUp && triggeredObject != null)
        {
            
            // 凍結 Rigidbody 旋轉和位置
            triggeredObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            // 使用 Lerp 方法平滑移動物體到原物體的位置
            triggeredObject.transform.position = Vector3.Lerp(triggeredObject.transform.position, transform.position, Time.deltaTime * moveSpeed);
            // 使用 Slerp 方法平滑旋轉物體到原物體的旋轉
            triggeredObject.transform.rotation = Quaternion.Slerp(triggeredObject.transform.rotation, transform.rotation, Time.deltaTime * moveSpeed);

        }
    }

    

    void PutDownObject()
    {
        // 將物體放下
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

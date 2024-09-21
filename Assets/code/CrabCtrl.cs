using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrabCtrl : MonoBehaviour
{
    public Button pickupButton;
    public Transform crabTransform; // 爪子的 Transform
    public float moveSpeed = 5f; // 移動速度
   
    

    private bool isBeingMoved = false;
    private GameObject triggeredObject;

    private void Start()
    {
        // 添加按鈕點擊事件
        pickupButton.onClick.AddListener(Pickup);
    }

    void Update()
    {
        if (isBeingMoved && triggeredObject != null)
        {
            // 使用 Lerp 方法平滑移動物體到原物體的位置
            triggeredObject.transform.position = Vector3.Lerp(triggeredObject.transform.position, transform.position, Time.deltaTime * moveSpeed);
            // 使用 Slerp 方法平滑旋轉物體到原物體的旋轉
            triggeredObject.transform.rotation = Quaternion.Slerp(triggeredObject.transform.rotation, transform.rotation, Time.deltaTime * moveSpeed);

            // 在一段時間後自動放下物體
            /*timeBeforeRelease -= Time.deltaTime;
            if (timeBeforeRelease <= 0f)
            {
                PutDownObject();
            }*/
        }
        
       
    }

    // 當物件碰到其他物件時觸發
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("碰到了");
        

        if (other.CompareTag("TriggerTag"))
        {
            triggeredObject = other.gameObject;
            // 啟用物體
            //triggeredObject.SetActive(true);
            // 將觸發的物體的位置設置為原物體的位置
            //triggeredObject.transform.position = transform.position;
            // 當觸碰到Tag:TriggerTag後這個物件就會跟著原物體移動
            isBeingMoved = true;

        }
        else if (other.CompareTag("Plane"))
        {
            // 放下物體
            PutDownObject();
        }
    }

    // 拾取物體的函數
    private void Pickup()
    {

        // 在這裡放置拾取物體的代碼，例如將物體設為玩家的子物體
        // 你可以使用 transform.parent = playerTransform; 之類的代碼
        Debug.Log("Object picked up!");

        // 啟用追隨
        isBeingMoved = true;
    }

    private void PutDownObject()
    {

        isBeingMoved = false;
        /*// 將物體放在原物體的正下方，偏移量可以根據需求調整
        float yOffset = -1.0f; // 垂直偏移
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
        triggeredObject.transform.position = newPosition;*/

        // 將物體的旋轉角度設置為原物體的旋轉角度
        //triggeredObject.transform.rotation = transform.rotation;
    }


    // 將物件平滑移動到目標位置
    /* void MoveObjectTowardsTarget()
     {
         // 使用Lerp函數實現平滑移動
         transform.position = Vector3.Lerp(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

         // 檢查是否已經接近目標位置，可以根據實際情況調整閾值
         if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
         {
             // 停止移動，放下物件
             isBeingMoved = false;
             Debug.Log("物件已經到達目標位置");
         }
     }*/
}

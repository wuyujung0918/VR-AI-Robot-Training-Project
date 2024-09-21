using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatorCtrl : MonoBehaviour
{
    
    public Button BtnBlow, BtnClose, BtnVomit;

    private Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        BtnVomit.onClick.AddListener(Crab);
        BtnClose.onClick.AddListener(Close);
        BtnBlow.onClick.AddListener(Blow);
    }

    void Crab()
    {
        animator.SetBool("idle", false);
        animator.SetBool("blow", false);
        animator.SetBool("crab", true);
    }



    void Close()
    {
        animator.SetBool("idle", true);
        animator.SetBool("crab", false);
        animator.SetBool("blow", false);

       
    }

    void Blow()
    {
        animator.SetBool("idle", false);
        animator.SetBool("crab", false);
        animator.SetBool("blow", true);
    }

   
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    //public GameObject inventoryPanel;
    Animator anim;
    public static bool activeInven = false;
    public InventoryUI instance;

    void start() {
        instance = this;
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
        //inventoryPanel.SetActive(false);
    }
    private void Update()
    {
        //Open Inven
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //input Tab
            if (activeInven == false)
            {
                anim.SetBool("isKeyDown", true);
                //inventoryPanel.SetActive(true);
                activeInven = true;
            }
            else
            {
                anim.SetBool("isKeyDown", false);
                activeInven = false;
            }
        }
    }

    public void Exit()
    {
        anim.SetBool("isKeyDown", false);
        activeInven = false;
    }

}

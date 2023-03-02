using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActive : MonoBehaviour
{
    //public int Music_of_Sue = 0;
    public GameObject QuestObject;
    //public InventoryUI invenUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickUse()
    {
        //invenUI.activeInven = false;
        InventoryUI.activeInven = false;
        QuestObject.SetActive(true);
        //Music_of_Sue = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prerequisite : MonoBehaviour
{
    //If true, check for this item
    public bool requireItem;
    
    //Switcher to watch
    public Switcher watchSwitcher;

    //If requireItem, check this collector
    public Collector checkCollector;
    
    //If true, block access to node
    public bool nodeAccess;

    //Check if prerequisite is met
    public bool Complete
    {
        get 
        {
            if(!requireItem)
            {
                return watchSwitcher.state; 
            }
            else
            {
                return GameManager.ins.itemHeld.itemName == checkCollector.myItem.itemName;
            }
        }
    }
}

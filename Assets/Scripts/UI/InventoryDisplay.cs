using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    Text displayText;

    private void Awake() 
    {
        displayText = GetComponent<Text>();
        displayText.text = "Item held: none";
    }

    public void UpdateDisplay()
    {
        string displayName;

        if(GameManager.ins.itemHeld != null)
        {
            displayName = GameManager.ins.itemHeld.itemName;
        }
        else
        {
            displayName = "None";
        }

        displayText.text = "Item Held: " + displayName;
    }
}

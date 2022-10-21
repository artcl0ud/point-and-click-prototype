using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    public IVCanvas ivCanvas;
    public OBSCamera obsCamera;
    public InventoryDisplay InvDisplay;

    [HideInInspector]
    public Node currentNode;
    public Node startingNode;
    
    //For multiple items in inventory; use an array or list were you can add/subtract elements from
    public Item itemHeld;

    public CameraRig rig;
    
    void Awake() 
    {
        if(ins != null && ins != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            ins = this;
        }

        ivCanvas.gameObject.SetActive(false);
        obsCamera.gameObject.SetActive(false);
    }

    void Start() 
    {
        startingNode.Arrive();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && currentNode.GetComponent<Prop>() != null)
        {
            if(ivCanvas.gameObject.activeInHierarchy)
            {
                ivCanvas.Close();
                return;
            }
            if(obsCamera.gameObject.activeInHierarchy)
            {
                obsCamera.Close();
                return;
            }
            currentNode.GetComponent<Prop>().loc.Arrive();
        }
    }
}

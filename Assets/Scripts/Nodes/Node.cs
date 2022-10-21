using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Node : MonoBehaviour
{
    public Transform cameraPosition;
    public List<Node> reachableNodes = new List<Node>();
    public bool ignoreCameraRotation;
    
    [HideInInspector]
    public Collider col;

    // Start is called before the first frame update
    void Awake()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
    }

    void OnMouseDown() 
    {
        Arrive();
    }

    public virtual void Arrive()
    {
        //leave existing currentNode if one exists
        if (GameManager.ins.currentNode != null)
        {
            GameManager.ins.currentNode.Leave();
        }

        //set currentNode
        GameManager.ins.currentNode = this;

        //TODO: Add that when moving to a new location, and that Location does not have a prop attached, move to that location while keeping the camera position the same

        //move cameraPosition
        GameManager.ins.rig.AlignTo(cameraPosition);

        //turn off own collider
        if (col != null)
        {
            col.enabled = false;
        }

        //turn on colliders of reachable nodes from current node
        SetReachableNodes(true);
    }

    public virtual void Leave()
    {
        //turn off colliders of unreachable nodes from current node
        SetReachableNodes(false);
    }

    public void SetReachableNodes(bool set)
    {
        foreach (Node node in reachableNodes)
        {
            if (node.col != null)
            {
                if(node.GetComponent<Prerequisite>() && node.GetComponent<Prerequisite>().nodeAccess)
                {
                    if(node.GetComponent<Prerequisite>().Complete)
                    {
                        node.col.enabled = set;
                    }
                } 
                else 
                {
                    node.col.enabled = set;
                }
            }
        }
    }
}
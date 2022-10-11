using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Node : MonoBehaviour
{
    public Transform cameraPosition;
    public List<Node> reachableNodes = new List<Node>();
    
    [HideInInspector]
    public Collider col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
    }

    void OnMouseDown() 
    {
        Arrive();
    }

    public void Arrive()
    {
        //leave existing currentNode if one exists
        if (GameManager.ins.currentNode != null)
        {
            GameManager.ins.currentNode.Leave();
        }

        //set currentNode
        GameManager.ins.currentNode = this;

        //set cameraPosition
        Camera.main.transform.position = cameraPosition.position;
        Camera.main.transform.rotation = cameraPosition.rotation;

        //turn off own collider
        if (col != null)
        {
            col.enabled = false;
        }

        //turn on colliders of reachable nodes
        foreach (Node node in reachableNodes)
        {
            if (node.col != null)
            {
                node.col.enabled = true;
            }
        }
    }

    public void Leave()
    {
        //turn off colliders of reachable nodes
        foreach (Node node in reachableNodes)
        {
            if (node.col != null)
            {
                node.col.enabled = false;
            }
        }
    }
}
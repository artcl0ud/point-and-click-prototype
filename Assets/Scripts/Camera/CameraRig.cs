using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraRig : MonoBehaviour
{
    public Transform x_Axis;
    public Transform y_Axis;
    public float moveTime;

    public void AlignTo(Transform target)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(y_Axis.DOMove(target.position, moveTime));
        
        if(GameManager.ins.currentNode.ignoreCameraRotation != false)
        {
            return;
        }
        else
        {
            seq.Join(y_Axis.DORotate(new Vector3(0f, target.rotation.eulerAngles.y , 0f), moveTime));
            seq.Join(x_Axis.DOLocalRotate(new Vector3(target.rotation.eulerAngles.x, 0f, 0f), moveTime));
        }
    }
}
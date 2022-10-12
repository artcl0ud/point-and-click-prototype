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
        seq.Append(yAxis.DOMove(target.position, moveTime));
        seq.Join(yAxis.DORotate(new Vector3(0f, target.rotation.eulerAngles.y , 0f), moveTime));
        seq.Join(xAxis.DOLocalRotate(new Vector3(target.rotation.eulerAngles.x, 0f, 0f), moveTime));
    }
}
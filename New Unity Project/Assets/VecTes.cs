using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VecTes : MonoBehaviour
{
    public Transform v1;
    public Transform v2;
    [Range(0f, 1f)]
    public float lerp;
    private void OnDrawGizmos()
    {
        Vector3 b = v2.position - v1.position;
        Gizmos.DrawLine(v1.position,v2.position);
        Gizmos.DrawSphere(v1.position + b*lerp, .5f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vec : MonoBehaviour
{
    public GameObject first;
    public GameObject second;

    private void OnDrawGizmos()
    {
        Vector3 testV = second.transform.position - first.transform.position;
        Gizmos.DrawLine(Vector3.zero, testV);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, testV / testV.magnitude);
    }
}

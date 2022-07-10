using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quatt : MonoBehaviour
{
    public GameObject target;
    [Range(0f, 1f)]
    public float t;
    public Quaternion init;

    private void Start()
    {
        init = transform.rotation;
    }
    private void Update()
    {
        Vector3 lookVec = target.transform.position - transform.position;
        lookVec = lookVec.normalized;

        Quaternion q = Quaternion.AngleAxis(Mathf.Acos(Vector3.Dot(Vector3.forward, lookVec)) * Mathf.Rad2Deg, Vector3.Cross(Vector3.forward, lookVec));

        transform.rotation = Quaternion.Slerp(init, q, t);
    }
}

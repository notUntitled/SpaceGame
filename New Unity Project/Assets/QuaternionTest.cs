using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionTest : MonoBehaviour
{
    public float angle = 1;
    private void Update()
    {
        angle += .1f;
        Quaternion q = Quaternion.AngleAxis(angle * Mathf.Rad2Deg * Time.deltaTime, Vector3.forward);
        transform.rotation = q;
    }
}

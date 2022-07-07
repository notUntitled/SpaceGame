using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public Ray mouseCast;
    public Vector3 mouseVec;
    public Camera cam;
    public float mouseMagnitude;
    public Transform ship;
    public float visualMultiplier;
    public Vector3 suppliedForce;
    public float deNormalizer;
    public float xRot = 0;
    public float yRot = 0;
    //Z - A/D
    public float zRot = 0;
    public float duoDeNormalizer;
    private void OnDrawGizmos()
    {
        mouseCast = cam.ScreenPointToRay(Input.mousePosition);

        mouseVec = mouseCast.direction;
        mouseMagnitude = mouseVec.magnitude;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(cam.transform.position, cam.transform.position + (mouseVec * visualMultiplier));

    }

    private void Update()
    {
        if (Input.anyKey)
        {
            if (ship.rotation.z < 70 && Input.GetKey(KeyCode.A))
            {
                zRot += 1;
            }
            if (ship.rotation.z > -70 && Input.GetKey(KeyCode.D))
            {
                zRot -= 1;
            }

            if (Input.GetMouseButton(0))
            {
                //Either move-to or use a physics approach with Force and Rigidbody
                ship.GetComponent<Rigidbody>().AddForce(mouseVec * deNormalizer);
            }
        }
        else if (ship.rotation.z > 0) //Stabilizer
        {
            zRot -= 1;
        }
        else if (ship.rotation.z < 0)
        {
            zRot += 1;
        }
        ship.Rotate(xRot/ duoDeNormalizer, yRot/ duoDeNormalizer, zRot/ duoDeNormalizer);
    }


    //Lerp stabilizer thingy probably
}

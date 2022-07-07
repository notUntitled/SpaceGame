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
    public GameObject shot;
    public Transform spawnR;
    public Transform spawnL;
    public bool alternator;
    public float shotSpeedMult;
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
        if (ship.rotation.z > 70)
        {
            ship.Rotate(0, 0, -(ship.rotation.z - 70));
        }
        if (ship.rotation.z < -70)
        {
            ship.Rotate(0, 0, (ship.rotation.z + 70));
        }
        if (Input.anyKey)
        {
            if (ship.rotation.y < 70 && Input.GetKey(KeyCode.A))
            {
                yRot += .1f;
            }
            if (ship.rotation.y > -70 && Input.GetKey(KeyCode.D))
            {
                yRot -= .1f;
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                Vector3 spawnpos = Vector3.zero;
                switch (alternator)
                {
                    case true:
                        spawnpos = spawnR.position;
                        alternator = !alternator;
                        break;
                    case false:
                        spawnpos = spawnL.position;
                        alternator = !alternator;
                        break;
                }
                GameObject fire = Instantiate(shot, spawnpos, Quaternion.identity);
                fire.GetComponent<Rigidbody>().AddForce(mouseVec * shotSpeedMult);
            }
            {
                //Either move-to or use a physics approach with Force and Rigidbody
                ship.GetComponent<Rigidbody>().AddForce(mouseVec * deNormalizer);
            }

            if (Input.GetMouseButton(0))
            {
                //Either move-to or use a physics approach with Force and Rigidbody
                ship.GetComponent<Rigidbody>().AddForce(mouseVec * deNormalizer);
            }
        }
        /*else if (ship.rotation.z > 0) //Stabilizers
        {
            zRot -= (ship.rotation.z/2);
        }
        else if (ship.rotation.z < 0)
        {
            zRot += (ship.rotation.z / 2);
        }*/
        ship.Rotate(xRot/ duoDeNormalizer, yRot/ duoDeNormalizer, zRot/ duoDeNormalizer);
    }


    //Lerp stabilizer thingy probably
}

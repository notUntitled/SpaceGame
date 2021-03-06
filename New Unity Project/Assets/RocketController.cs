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
    public float velocityClamp = 200f;
    private void OnDrawGizmos()
    { 
        Gizmos.color = Color.red;
        Gizmos.DrawLine(cam.transform.position, cam.transform.position + (mouseVec * visualMultiplier));
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(spawnL.position, mouseVec* visualMultiplier + spawnL.position);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(spawnR.position, mouseVec*visualMultiplier + spawnR.position);
    }

    private void Update()
    {
        mouseCast = cam.ScreenPointToRay(Input.mousePosition);

        mouseVec = mouseCast.direction;
        mouseMagnitude = mouseVec.magnitude;
        yRot = 0;
        xRot = 0;
        if (ship.rotation.y > 70)
        {
            ship.Rotate(0, 0, -(ship.rotation.y - 70));
        }
        if (ship.rotation.y < -70)
        {
            ship.Rotate(0, 0, (ship.rotation.y + 70));
        }
        if (Input.anyKey)
        {
            if (ship.rotation.y < 70 && Input.GetKey(KeyCode.D))
            {
                yRot += 25f;
            }
            if (ship.rotation.y > -70 && Input.GetKey(KeyCode.A))
            {
                yRot -= 25f;
            }
            if (ship.rotation.x > -70 && Input.GetKey(KeyCode.W))
            {
                xRot -= 25f;
            }
            if (ship.rotation.x < 70 && Input.GetKey(KeyCode.S))
            {
                xRot += 25f;
            }
            if (Input.GetKey(KeyCode.F))
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
                fire.transform.Rotate(90, 0, 0);
                fire.GetComponent<Rigidbody>().AddForce(mouseVec * shotSpeedMult *50);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                ship.GetComponent<Rigidbody>().drag = 10 * ship.GetComponent<Rigidbody>().drag;
            }
                if (Input.GetMouseButton(0))
            {
                
                AddForceInDirec(mouseVec);
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

    public void AddForceInDirec(Vector3 direction)
    {
        ship.GetComponent<Rigidbody>().AddForce(direction * deNormalizer);
        ship.GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(ship.GetComponent<Rigidbody>().velocity, velocityClamp);
    }
    //Lerp stabilizer thingy probably
}

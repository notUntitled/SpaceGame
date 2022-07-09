using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondController : MonoBehaviour
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
    public float speedMultiplier;
    public float duoDeNormalizer;
    public GameObject shot;
    public Transform spawnR;
    public Transform spawnL;
    public bool alternator;
    public float shotSpeedMult;
    public float velocityClamp = 200f;
    public float rotationSpeed;
    private void OnDrawGizmos()
    {
        mouseCast = cam.ScreenPointToRay(Input.mousePosition);

        mouseVec = mouseCast.direction;
        mouseMagnitude = mouseVec.magnitude;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(cam.transform.position, cam.transform.position + (mouseVec * visualMultiplier));
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(spawnL.position, mouseVec * visualMultiplier + spawnL.position);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(spawnR.position, mouseVec * visualMultiplier + spawnR.position);
    }

    private void Update()
    {
        yRot = 0;
        xRot = 0;
        zRot = 0;
        if (Input.anyKey)
        {
            if (ship.rotation.y < 70 && Input.GetKey(KeyCode.D))
            {
                yRot += 1f;
                zRot -= 1f;
            }
            if (ship.rotation.y > -70 && Input.GetKey(KeyCode.A))
            {
                yRot -= 1f;
                zRot += 1f;
            }
            if (ship.rotation.x > -70 && Input.GetKey(KeyCode.W))
            {
                xRot -= 1f;
            }
            if (ship.rotation.x < 70 && Input.GetKey(KeyCode.S))
            {
                xRot += 1f;
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
                fire.transform.Rotate(fire.transform.localRotation.x + 90, transform.rotation.y, transform.rotation.z);
                fire.GetComponent<Rigidbody>().AddForce(mouseVec * shotSpeedMult * 50);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                ship.GetComponent<Rigidbody>().drag = 10 * ship.GetComponent<Rigidbody>().drag;
            }
            if (Input.GetMouseButton(0))
            {
                transform.Translate(mouseVec * speedMultiplier * Time.deltaTime, Space.World);
            }
        }
        else
        {
            ship.rotation = Quaternion.RotateTowards(ship.rotation, new Quaternion(Quaternion.identity.x + AutoCorrect(ship.rotation.x), Quaternion.identity.y + AutoCorrect(ship.rotation.y), 
                Quaternion.identity.z + AutoCorrect(ship.rotation.z), Quaternion.identity.w + AutoCorrect(ship.rotation.w))
            {

            }, Time.deltaTime * rotationSpeed);
        }
        /*else if (ship.rotation.z > 0) //Stabilizers
        {
            zRot -= (ship.rotation.z/2);
        }
        else if (ship.rotation.z < 0)
        {
            zRot += (ship.rotation.z / 2);
        }*/
        ship.Rotate(xRot / duoDeNormalizer, yRot / duoDeNormalizer, zRot / duoDeNormalizer);
    }
    //Lerp stabilizer thingy probably

    float AutoCorrect(float rotation)
    {
        //Find nearest 45 deg angle
        //8 AM. Cant think of many efficient ways to solve this. I'll come back to this later for optimization.
        float[] degs = { 0, 45, 90, 135, 180 };
        bool pos = rotation >= 0 ? true : false;
        float closestRot = 1000;
        for(int x = 0; x < degs.Length; x++)
        {
            if(Mathf.Abs(rotation) - degs[x] < closestRot)
                {
                    closestRot = degs[x];
                }
        }
        if (pos)
        {
            Debug.Log(closestRot);
            return closestRot;
        }
        else
        {
            Debug.Log(closestRot);
            return -closestRot;
        }
    }
}

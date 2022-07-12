using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondController : MonoBehaviour
{
    public float entityHealth = 50;
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
    public bool dead;
    public ParticleSystem burn;
    private void Start()
    {
        dead = false;
    }
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
        if (!dead)
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
                ship.rotation = Quaternion.RotateTowards(ship.rotation, new Quaternion(AutoCorrect(ship.rotation.x, 0), AutoCorrect(ship.rotation.y, 0),
                    AutoCorrect(ship.rotation.z, 1), AutoCorrect(ship.rotation.w, 0))
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
        else
        {

        }
    }
        //Lerp stabilizer thingy probably

        float AutoCorrect(float rotation, int intensity)
        {
        //Find nearest 45 deg angle
        //8 AM. Cant think of many efficient ways to solve this. I'll come back to this later for optimization.
        float[] degs = { 0, .125f, .25f, .375f, .5f, .625f, .75f, .875f, 1f };
        switch (intensity)
        {
            case 0:
                degs[0] = 0;
                degs[1] = .125f;
                degs[2] = .25f;
                degs[3] = .375f;
                degs[4] = .5f;
                degs[5] = .625f;
                degs[6] = .75f;
                degs[7] = .875f;
                degs[8] = 1f;
                break;
            case 1:
                degs[0] = 0;
                degs[1] = 0;
                degs[2] = .25f;
                degs[3] = 0;
                degs[4] = .5f;
                degs[5] = 0;
                degs[6] = .75f;
                degs[7] = 0;
                degs[8] = 1f;
                break;
        }
        bool pos = rotation >= 0 ? true : false;
        float closestRot = 1000;
        for(int x = 0; x < degs.Length; x++)
        {
            if(Mathf.Abs(Mathf.Abs(rotation) - degs[x]) < Mathf.Abs(Mathf.Abs(rotation) - closestRot))
                {
                    closestRot = degs[x];
                }
        }
        if (pos)
        {
            return closestRot;
        }
        else
        {
            return -closestRot;
        }
    }

    public void isDead()
    {
        dead = true;
        burningParticles();
    }
    public void dealDamage(float damage)
    {
        entityHealth -= damage;
        burn.Play();
    }

    void burningParticles()
    {
        burn.Play();
    }
}

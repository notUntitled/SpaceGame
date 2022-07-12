using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIstuff : MonoBehaviour
{
    public float entityHealth = 90;
    public GameObject player;
    public Vector3 direcToPlayer;
    public Quaternion enemyRotation;
    public float rotAngle;
    public Vector3 axis;
    public float speed;
    public bool alternator;
    public GameObject shot;
    public Transform spawnR;
    public Transform spawnL;
    public float shotSpeedMult;
    public float shotDelay;
    public bool canShoot;
    public bool dead;
    public AudioSource pew;
    public ParticleSystem burn;
    void Start()
    {
        //There's probably a more efficient way of doing this.
        burn = ParticleSystem.Instantiate<ParticleSystem>(burn);
        burn.transform.position = transform.position;
        burn.Pause();
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            shotDelay += Time.deltaTime;
            if (shotDelay > .25f)
            {
                canShoot = true;
            }
            //NEED TO NORMALIZE ELSE THE QUATERNION IS PURE.
            direcToPlayer = (player.transform.position - transform.position).normalized;

            //Acosine of the Dot Product between the Forward Vector and the desired Vector (DirecToPlayer). Convert to Deg.
            rotAngle = Mathf.Acos(Vector3.Dot(Vector3.forward, direcToPlayer)) * Mathf.Rad2Deg;
            //Cross product between the Forward Vector and the direction the enemy should be looking.
            axis = Vector3.Cross(Vector3.forward, direcToPlayer);
            enemyRotation = Quaternion.AngleAxis(rotAngle, axis);


            transform.rotation = enemyRotation;

            //Move ship to player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);

            if (canShoot && (player.transform.position - transform.position).magnitude < 25f)
            {
                shotDelay = 0;
                canShoot = false;
                ShootShot();
            }
        }
        }

        public void ShootShot()
    {
        if (!pew.isPlaying)
        {
            pew.Play();
        }
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
        fire.transform.rotation = Quaternion.AngleAxis(Mathf.Acos(Vector3.Dot(Vector3.forward, direcToPlayer)) * Mathf.Rad2Deg, Vector3.Cross(Vector3.forward, direcToPlayer)) * Quaternion.Euler(90, 0, 0);
        fire.GetComponent<Rigidbody>().AddForce(direcToPlayer * shotSpeedMult * 50);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, player.transform.position);
    }

    public void isDead()
    {
        dead = true;
        burningParticles();
    }

    void burningParticles()
    {
        burn.transform.position = transform.position;
        burn.Play();
    }
}

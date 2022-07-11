using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIstuff : MonoBehaviour
{
    public GameObject player;
    public Vector3 direcToPlayer;
    public Quaternion enemyRotation;
    public float rotAngle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        direcToPlayer = player.transform.position;
        enemyRotation = Quaternion.AngleAxis();


        transform.rotation = enemyRotation;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, direcToPlayer);
    }
}

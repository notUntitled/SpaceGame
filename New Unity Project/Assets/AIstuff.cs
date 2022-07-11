using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIstuff : MonoBehaviour
{
    public GameObject player;
    public Vector3 direcToPlayer;
    public Quaternion enemyRotation;
    public float rotAngle;
    public Vector3 axis;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //NEED TO NORMALIZE ELSE THE QUATERNION IS PURE.
        direcToPlayer = (player.transform.position - transform.position).normalized;

        //Acosine of the Dot Product between the Forward Vector and the desired Vector (DirecToPlayer). Convert to Deg.
        rotAngle = Mathf.Acos(Vector3.Dot(Vector3.forward, direcToPlayer)) * Mathf.Rad2Deg;
        //Cross product between the Forward Vector and the direction the enemy should be looking.
        axis = Vector3.Cross(Vector3.forward, direcToPlayer);    
        enemyRotation = Quaternion.AngleAxis(rotAngle, axis);


        transform.rotation = enemyRotation;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, player.transform.position);
    }
}

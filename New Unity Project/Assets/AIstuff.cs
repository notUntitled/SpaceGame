using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIstuff : MonoBehaviour
{
    public GameObject player;
    public Vector3 direcToPlayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direcToPlayer = player.transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, direcToPlayer);
    }
}

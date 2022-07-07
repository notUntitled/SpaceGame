using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float dist;
    public GameObject player;
    public Vector3 playerpos;

    private void Start()
    {
        player = GameObject.Find("player"); 
    }
    void Update()
    {
        playerpos = player.transform.position;
        if ((transform.position - playerpos).magnitude > 1000f)
        {
            GameObject.Destroy(gameObject);
        }
    }
}

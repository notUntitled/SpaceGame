using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShot : MonoBehaviour
{
    public float damage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {         
            AIstuff entity = collision.gameObject.GetComponent<AIstuff>();
            entity.entityHealth -= damage;
            GameObject.Destroy(gameObject);
            Debug.Log($" Dealt {damage} to enemy");
            if (entity.entityHealth <= 0)
            {
                entity.isDead();
            }
        }
    }
}

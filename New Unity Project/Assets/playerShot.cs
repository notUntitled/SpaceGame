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
            SecondController entity = collision.gameObject.GetComponent<SecondController>();
            entity.entityHealth -= damage;
            GameObject.Destroy(gameObject);
            if (entity.entityHealth <= 0)
            {
                entity.isDead();
            }
        }
    }
}

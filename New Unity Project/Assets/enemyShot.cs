using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShot : MonoBehaviour // I COULD use inheritance for both of these but it's a small project anyway...
{
    public float damage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SecondController entity = collision.gameObject.GetComponent<SecondController>();
            entity.dealDamage(damage);
            GameObject.Destroy(gameObject);
            Debug.Log($" Dealt {damage} to enemy");
            if (entity.entityHealth <= 0)
            {
                entity.isDead();
            }
        }
    }
}

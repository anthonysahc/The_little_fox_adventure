using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemieAttack : MonoBehaviour
{
    [SerializeField] float damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        damage = gameManager.InstanceGame.Damage;

        if (collision.gameObject == gameManager.InstanceGame.Player && !playerInventory.InstanceInventory.IsTakeDamage)
        {
            playerInventory.InstanceInventory.TakeDamage(damage);
            if(gameObject.layer == 12)
            {
                Destroy(gameObject);
            }
        }
    }
}

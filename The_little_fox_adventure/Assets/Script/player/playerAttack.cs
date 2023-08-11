using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    [SerializeField] float jumpEnemiePower = 15;
    [SerializeField] GameObject soundBound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemie" && !playerInventory.InstanceInventory.IsTakeDamage)
        {
            if(soundBound)
            {
                Instantiate(soundBound, transform.position, Quaternion.identity);
            }
            collision.gameObject.GetComponent<enemieDestroy>().enemieDeath();
            GetComponent<playerController>().boundEnemie(jumpEnemiePower);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemieDestroy : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void enemieDeath()
    {
        setFalseColider();
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 
        animator.SetBool("isDeath", true);
    }

    public void destroyEnemie()
    {
        Destroy(gameObject);
    }

    private void setFalseColider()
    {
        foreach (Collider2D c in GetComponents<Collider2D>())
        {
            c.enabled = false;
        }
    }
}

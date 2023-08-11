using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathZone : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("L_ENEMY") || collision.gameObject.layer == LayerMask.NameToLayer("L_SPIKE"))
        {
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject == gameManager.InstanceGame.Player)
        {
            gameManager.InstanceGame.gameLose();
        }
    }
}

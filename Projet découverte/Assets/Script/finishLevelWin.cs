using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishLevelWin : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == gameManager.InstanceGame.Player)
        {
            gameManager.InstanceGame.gameWin();
        }
    }
}

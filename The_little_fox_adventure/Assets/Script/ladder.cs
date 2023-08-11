using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameManager.InstanceGame.Player.GetComponent<playerMovement>().SetCanClimb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.InstanceGame.Player.GetComponent<playerMovement>().SetCanClimb = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerSpawn : MonoBehaviour
{
    private void Awake()
    {
        gameManager.InstanceGame.Player.transform.position = transform.position;
        gameManager.InstanceGame.MainCamera.transform.position = transform.position;
    }
}

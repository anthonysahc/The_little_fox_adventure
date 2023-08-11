using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSpecificScene : MonoBehaviour
{
    public string sceneName;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == gameManager.InstanceGame.Player)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

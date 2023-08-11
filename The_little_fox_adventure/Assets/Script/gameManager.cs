using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    
    #region Sigleton
    private static gameManager instanceGame;
    public static gameManager InstanceGame
    {
        get
        {
            if (instanceGame == null)
                instanceGame = FindObjectOfType<gameManager>();
            return instanceGame;
        }
    }
    #endregion

    float heal;
    float damage;
    bool isPause = false;
    bool canPause = false;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject mainCamera;

    public float Heal { get { return heal; } }
    public float Damage { get { return damage; } }
    public GameObject Player { get { return player; } }
    public GameObject MainCamera { get { return mainCamera; } }

    void Start()
    {
        Time.timeScale = 0;
        normalMode();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && canPause)
        {
            if(isPause)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void easyMode()
    {
        heal = 0.5f;
        damage = 0.25f;
    }

    public void normalMode()
    {
        heal = 0.5f;
        damage = 0.5f;
    }

    public void hardMode()
    {
        heal = 0.25f;
        damage = 1f;
    }

    public void gameLose()
    {
        UIManager.InstanceUI.printLose();
        Time.timeScale = 0;
    }

    public void gameWin()
    {
        UIManager.InstanceUI.printWin();
        Time.timeScale = 0;
    }
    public void restartGame()
    {
        GetComponent<dontDestroyOnLoadScene>().destroyElement();
        SceneManager.LoadScene("Level01");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void startGame()
    {
        UIManager.InstanceUI.hidMenu();
        int level = UIManager.InstanceUI.Level;
        Time.timeScale = 1;
        if (level == 1)
        {
            SceneManager.LoadScene("Level02");
        }
        else if (level == 2)
        {
            SceneManager.LoadScene("Level03");
        }
        canPause = true;
    }

    public void resume()
    {
        Time.timeScale = 1;
        isPause = false;
        UIManager.InstanceUI.printPause(isPause);
    }

    private void pause()
    {
        Time.timeScale = 0;
        isPause = true;
        UIManager.InstanceUI.printPause(isPause);
    }
}

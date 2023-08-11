using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    #region Sigleton
    private static UIManager instanceUI;
    public static UIManager InstanceUI
    {
        get
        {
            if (instanceUI == null)
                instanceUI = FindObjectOfType<UIManager>();
            return instanceUI;
        }
    }
    #endregion

    [SerializeField] Transform dificultyDropdown;
    [SerializeField] Transform levelDropdown;
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject pausePanel;

    private int level = 0;

    public int Level { get { return level; } }

    private void Start()
    {
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    public void changeDificulty()
    {
        int dificultyIndex = dificultyDropdown.GetComponent<Dropdown>().value;

        if (dificultyIndex == 0)
        {
            gameManager.InstanceGame.easyMode();
        }
        else if (dificultyIndex == 1)
        {
            gameManager.InstanceGame.normalMode();
        }
        else if (dificultyIndex == 2)
        {
            gameManager.InstanceGame.hardMode();
        }
    }

    public void changeLevel()
    {
        level = levelDropdown.GetComponent<Dropdown>().value;
    }

    public void hidMenu()
    {
        menuPanel.SetActive(false);
    }

    public void printLose()
    {
        losePanel.SetActive(true);
    }

    public void printWin()
    {
        winPanel.SetActive(true);
    }

    public void printPause(bool print)
    {
        pausePanel.SetActive(print);
    }
}

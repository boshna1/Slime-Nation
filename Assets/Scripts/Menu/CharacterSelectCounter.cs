using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectCounter : MonoBehaviour
{
    [SerializeField] int playerCount;
    [SerializeField] int readyCount;
    [SerializeField] bool notCancelled = true;
    [SerializeField] bool confirm = false;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject[] buttons = new GameObject[4];


    private void Start()
    {
        panel.SetActive(false);
    }
    void Update()
    {
        if ((readyCount >= playerCount) && notCancelled && playerCount != 0)
        {
            confirm = true;
            
        }
        if (readyCount < playerCount) 
        {
            confirm = false;
        }
        panel.SetActive(confirm);
        for (int i = 0; i < 4; i++)
        {
            buttons[i].SetActive(!confirm);
        }



    }

    public int GetPlayerCount()
    {
        return playerCount;
    }
    public void AddReady()
    {
        readyCount++;
    }

    public void SubReady()
    {
        if (readyCount > 0)
        {
            readyCount--;
        }
    }

    public void IncreasePlayerCount()
    {
        playerCount++;
    }

    public void RemovePlayerCount() 
    {
        if (playerCount != -1)
        {
            playerCount--;
        }
    }

    public void ManualLoad()
    {
        SceneManager.LoadScene("BattleScreen");
    }

    public bool GetIsConfirm()
    {
        return confirm;
    }

    public void SetIsConfirm(bool con)
    {
        confirm = con;
    }

    public void Menu()
    { 
                SceneManager.LoadScene("Main Menu");      
    }
}

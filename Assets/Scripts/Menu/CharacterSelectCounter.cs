using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectCounter : MonoBehaviour
{
    [SerializeField] int playerCount;
    [SerializeField] int readyCount;
    [SerializeField] bool notCancelled = true;
    [SerializeField] bool confirm = false;
    [SerializeField] GameObject panel;
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
        if (confirm)
        {
            panel.SetActive(true);
        }
        if (!confirm)
        {
            panel.SetActive(false);
        }
    }
    public void AddReady()
    {
        readyCount++;
    }

    public void SubReady()
    {
        readyCount--;
    }

    public void IncreasePlayerCount()
    {
        playerCount++;
    }

    public void RemovePlayerCount() 
    {
        playerCount--;
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectCounter : MonoBehaviour
{
    [SerializeField] int playerCount;
    [SerializeField] int readyCount;
    void Update()
    {
        if (readyCount >= playerCount)
        {
            SceneManager.LoadScene("BattleScreen");
        }
    }

    public void AddReady()
    {
        readyCount++;
    }

    public void SetPlayerCount(int num)
    {
        playerCount = num;
    }
}

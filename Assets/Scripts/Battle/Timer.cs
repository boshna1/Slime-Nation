using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timer;
    float battleTime;
    bool battleRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        battleTime = 300;
    }

    // Update is called once per frame
    void Update()
    {
        if (battleRunning)
        {
            battleTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(battleTime / 60f);
            int seconds = Mathf.FloorToInt(battleTime % 60f);
            int milliseconds = (Mathf.FloorToInt(battleTime * 100f) % 100);
            timer.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        }     
    }

    public void SetBattle(bool con)
    {
        battleRunning = con;
    }
}

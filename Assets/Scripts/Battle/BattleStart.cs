using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class BattleStart : MonoBehaviour
{
    [SerializeField] Text countdown;
    [SerializeField] Timer timer;
    [SerializeField] float timerFloat = 3;
    bool isCountdown = false;
    // Start is called before the first frame update
    void Start()
    {
        isCountdown = true;
        StartCoroutine(StartCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountdown) 
        {
            timerFloat -= Time.deltaTime;
            countdown.text = Mathf.Round(timerFloat).ToString();
        }   
        if (timerFloat <= 0)
        {
            isCountdown = false;
            timerFloat = 0;
            countdown.text = "";
        }
    }

    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(3);
        timer.SetBattle(true);
    }
}

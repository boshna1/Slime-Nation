using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProfileAssign : MonoBehaviour
{
    [SerializeField] GameObject[] profiles = new GameObject[4];
    DataHolder dataHolder;
    [SerializeField] string[] characterNames = new string[4];
    // Start is called before the first frame update
    void Start()
    {
        dataHolder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
        characterNames = dataHolder.GetChars();     
        for (int i = 0; i < 4; i++) 
        {
            profiles[i].transform.GetChild(1).GetComponent<Text>().text = characterNames[i];
        }
        characterNames = dataHolder.GetNames();
        for (int i = 0; i < 4; i++)
        {
            profiles[i].transform.GetChild(0).GetComponent<Text>().text = characterNames[i];
        }
    }

    public string[] GetNames()
    {
        return characterNames;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSpawn : MonoBehaviour
{
    DataHolder dataHolder;
    string[] players = new string[4];
    GameObject[] playerObject = new GameObject[4];
    GameObject[] characterPrefabs = new GameObject[4];
    ProfileAssign profileAssign;
    void Awake()
    {
        profileAssign = GetComponent<ProfileAssign>();
        dataHolder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
        Dictionary<int, PlayerInput> temp = dataHolder.GetComponent<DataHolder>().GetPlayerValues();
        players = profileAssign.GetNames();
        for (int i = 0; i < temp.Count; i++) 
        {
            if (players[i] == "Lord")
            {
                playerObject[i] = Instantiate(characterPrefabs[0]);
            }
            if (players[i] == "John")
            {
                playerObject[i] = Instantiate(characterPrefabs[1]);
            }
            if (players[i] == "Sarah")
            {
                playerObject[i] = Instantiate(characterPrefabs[2]);
            }
            if (players[i] == "Door")
            {
                playerObject[i] = Instantiate(characterPrefabs[3]);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

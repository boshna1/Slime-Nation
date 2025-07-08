using System.Collections;
using System.Collections.Generic;
using UnityEditor.Analytics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class DataHolder : MonoBehaviour
{
    [SerializeField] Dictionary<int, PlayerInput> playerValues = new Dictionary<int, PlayerInput>();
    [SerializeField] string[] chars = new string[4];
    [SerializeField] string[] names = new string[4];
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        for (int i = 0; i < 4; i++) 
        {
            RemoveDict(i);
        }
    }
    public void IncreasePlayerCount(PlayerInput input)
    {
        int freeIndex = -1;

        for (int i = 0; i < 4; i++)
        {
            if (!playerValues.ContainsKey(i))
            {
                freeIndex = i;
                break;
            }
        }

        if (freeIndex == -1)
        {
            Debug.LogWarning("No free player slots!");
            return;
        }

        playerValues.Add(freeIndex, input);
        input.gameObject.GetComponent<PlayerUIController>().SetIndex(freeIndex);
        chars[freeIndex] = input.gameObject.name;
        names[freeIndex] = (freeIndex + 1).ToString();
        Debug.Log($"Player Added at index {freeIndex}");
    }

    public Dictionary<int, PlayerInput> GetPlayerValues()
    {
        return playerValues;
    }

    public void RemoveDict(int input)
    {
        if (playerValues.ContainsKey(input))
            Debug.Log($"Player {input}: {playerValues[input]}");
        if (playerValues[input] == null)
        {
            playerValues.Remove(input);
            Debug.Log($"Player {input}: none");
        }
    }

    public void SetInfo(int index)
    {
         chars[index] = playerValues[index].gameObject.name;
    }

    public string[] GetChars()
    {
        return chars;
    }
    public string[] GetNames()
    {
        return names;
    }
}

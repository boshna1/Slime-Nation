using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DataHolder : MonoBehaviour
{
    [SerializeField] Dictionary<string, PlayerInput> playerValues = new Dictionary<string, PlayerInput>();
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void AddData(Dictionary<string, PlayerInput> data)
    {
        playerValues = data;
    }
}

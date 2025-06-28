using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterSelectCursor : MonoBehaviour
{
    Vector3 cursorPosition;
    [SerializeField] Texture2D cursorImage;
    [SerializeField] GameObject cursor;
    [SerializeField] List<GameObject> cursorHolders = new List<GameObject>();
    [SerializeField] Camera cam;
    [SerializeField] GameObject canvas;
    Vector2 hotspot = new Vector2 (0, 0);

    bool interact = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorImage, hotspot, CursorMode.Auto);
    }

}

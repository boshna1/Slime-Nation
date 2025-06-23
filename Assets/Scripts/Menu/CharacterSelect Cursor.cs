using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectCursor : MonoBehaviour
{
    Vector3 cursorPosition;
    [SerializeField] Sprite cursorImage;
    [SerializeField] GameObject cursor;
    [SerializeField] List<GameObject> cursorHolders = new List<GameObject>();
    [SerializeField] Camera cam;
    [SerializeField] GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        cursorHolders.Add(Instantiate(cursor,transform.parent));
    }

    // Update is called once per frame
    void Update()
    {
        cursorPosition = Input.mousePosition;
        Vector3 worldCursorPosition = cam.ScreenToWorldPoint(new Vector3(cursorPosition.x, cursorPosition.y,canvas.transform.position.z - cam.transform.position.z));
        cursorHolders[0].transform.position = worldCursorPosition;    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private string description;
    private Texture2D cursorDef, cursorHover;

    private void Awake()
    {
        cursorDef = Resources.Load<Texture2D>("UI/Cursor");
        cursorHover = Resources.Load<Texture2D>("UI/Cursor_Interact");
        Cursor.SetCursor(cursorDef, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseOver()
    {
        Cursor.SetCursor(cursorHover, Vector2.zero, CursorMode.Auto);
        if(Input.GetButtonDown("Fire1"))
        {
            InteractiveObjectManager.current.Interact(description);
        }
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorDef, Vector2.zero, CursorMode.Auto);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKappla : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private AudioClip interact, collision;
    private AudioSource audioSource;
    [SerializeField] private Rigidbody2D cursor;
    private Vector2 offset;
    private float currentRot;
    private bool hooked;
    public static bool hookedWithOther;
    private Texture2D cursorDef, cursorHover;

    private void Awake()
    {
        cursorDef = Resources.Load<Texture2D>("UI/Cursor");
        cursorHover = Resources.Load<Texture2D>("UI/Cursor_Interact");
        Cursor.SetCursor(cursorDef, Vector2.zero, CursorMode.Auto);
        audioSource = GetComponent<AudioSource>();
        _rb = this.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        hookedWithOther = false;
    }

    void Update()
    {
        if(Input.GetButtonUp("Fire1"))
        {
            Drop();
        }

        if(hooked == true)
        {
            _rb.gravityScale = 0;
            _rb.position = Vector2.MoveTowards(_rb.position, (cursor.position + offset), 50 * Time.deltaTime);
            if(Input.GetButtonDown("Fire2"))
            {
                Drop();
                currentRot += 90;
                transform.rotation = Quaternion.Euler(0,0, currentRot);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        audioSource.pitch = Random.Range(0.8F, 1.2F);
        audioSource.clip = collision;
        audioSource.Play();
    }

    void Drop()
    {
        offset = new Vector2(0,0);
        hookedWithOther = false;
        _rb.gravityScale = 1;
        _rb.velocity = new Vector2(0, 0);
        hooked = false;
    }

    private void OnMouseOver()
    {
        Cursor.SetCursor(cursorHover, Vector2.zero, CursorMode.Auto);
        if(Input.GetButton("Fire1") && !hooked && !hookedWithOther)
        {
            audioSource.PlayOneShot(interact, 1F);
            hookedWithOther = true;
            hooked = true;
            offset = ((Vector2)transform.localPosition - (Vector2)cursor.transform.localPosition);
        }
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorDef, Vector2.zero, CursorMode.Auto);
    }
}

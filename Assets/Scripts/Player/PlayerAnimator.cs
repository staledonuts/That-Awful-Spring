using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private SpriteRenderer playerSprite;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        
        if(x != 0)
        {
            anim.Play("WalkPlayer");
        }
        else
        {
            anim.Play("IdlePlayer");
        }

        if(x > 0)
        {
            playerSprite.flipX = false;
        }
        if(x < 0)
        {
            playerSprite.flipX = true;
        }
    }
}

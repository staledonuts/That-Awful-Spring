using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidsPlaying : MonoBehaviour
{
    [SerializeField] private Animator girlAnim;
    [SerializeField] private Animator boyAnim;

    private SpriteRenderer girlSprite;
    private SpriteRenderer boySprite;

    [SerializeField] private float walkTimings, moveSpeed;
    private bool moveLeft;
    private bool moveRight;
    private float xPos;

    // Start is called before the first frame update
    void Start()
    {
        girlSprite = girlAnim.GetComponent<SpriteRenderer>();
        boySprite = boyAnim.GetComponent<SpriteRenderer>();
        StartCoroutine(timings());
    }

    // Update is called once per frame
    void Update()
    {
        if(moveRight)
        {
            xPos += Time.deltaTime * moveSpeed;
        }
        else if(moveLeft)
        {
            xPos -= Time.deltaTime * moveSpeed;
        }

        transform.position = new Vector3(xPos, transform.position.y, 0);    
    }

    IEnumerator timings()
    {
        moveLeft = false;

        boySprite.flipX = false;
        girlSprite.flipX = true;

        girlAnim.Play("GirlShoot");
        boyAnim.Play("BoyShoot");
        
        yield return new WaitForSeconds(2); 
        
        boySprite.flipX = false;
        girlSprite.flipX = false;
        girlAnim.Play("GirlWalk");
        boyAnim.Play("BoyWalk");
        
        moveRight = true;

        yield return new WaitForSeconds(walkTimings);

        moveRight = false;

        boySprite.flipX = false;
        girlSprite.flipX = true;
        girlAnim.Play("GirlShoot");
        boyAnim.Play("BoyShoot");
        
        yield return new WaitForSeconds(2); 
        

        boySprite.flipX = true;
        girlSprite.flipX = true;
        girlAnim.Play("GirlWalk");
        boyAnim.Play("BoyWalk");
        
        moveLeft = true;
        yield return new WaitForSeconds(walkTimings);
        StartCoroutine(timings());
    }
}

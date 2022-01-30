using UnityEngine;

public class ChangeGender : MonoBehaviour
{
    [SerializeField] private Sprite girl, boy;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        if(ChooseKid.previousGender == "Girl")
        {
            sprite.sprite = girl;
        }
        else
        {
            sprite.sprite = boy;
        }
    }
}

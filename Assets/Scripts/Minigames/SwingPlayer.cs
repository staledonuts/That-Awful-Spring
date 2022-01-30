using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class SwingPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip swingPush, daughterComplete;
    [SerializeField] private AudioClip[] daughterLaughs;
    [SerializeField] private float pushForce;
    [SerializeField] private float requiredY;
    [SerializeField] private string sceneToLoad;
    private int untilLaugh;
    private float _pushMultiplier;
    private bool _pushed;
    private bool _loadingScene;
    private bool _finished;
    private Rigidbody2D _swingRigidbody;

    private Texture2D cursorDef, cursorHover;

    private void Awake()
    {
        cursorDef = Resources.Load<Texture2D>("UI/Cursor");
        cursorHover = Resources.Load<Texture2D>("UI/Cursor_Interact");
        Cursor.SetCursor(cursorDef, Vector2.zero, CursorMode.Auto);

        audioSource = GetComponent<AudioSource>();
        _swingRigidbody = this.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _pushMultiplier = 1;
    }

    private void Update()
    {
        _swingRigidbody.AddForce(Vector2.left * .1F * Time.deltaTime);
        if(_swingRigidbody.velocity.x >= 0F && _pushed)
        {
            _pushed = false;
        }
        if(_swingRigidbody.position.y > requiredY)
        {
            _swingRigidbody.drag = 0;
            _finished = true;
        }

        if(_finished && !_loadingScene)
        {
            audioSource.PlayOneShot(daughterComplete);
            _loadingScene = true;
            StartCoroutine(LoadScene());
        }
    }

    private void OnMouseOver()
    {
        if(_finished) return;

        Cursor.SetCursor(cursorHover, Vector2.zero, CursorMode.Auto);

        if(Input.GetButtonDown("Fire1") && _swingRigidbody.velocity.x <= 0F)
        {
            if(!_pushed)
            {
                if(_swingRigidbody.drag > 0)
                {
                    _pushMultiplier += 0.1F;
                    _swingRigidbody.drag -= 0.02F;
                }
                audioSource.PlayOneShot(swingPush, 1F);
                untilLaugh++;
                if(untilLaugh > 3)
                {
                    audioSource.PlayOneShot(daughterLaughs[Random.Range(0, daughterLaughs.Length)], 1F);
                    untilLaugh = 0;
                }
                _swingRigidbody.AddForce(Vector2.left * _pushMultiplier * 40 * pushForce);
                _pushed = true;
            }
        }
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorDef, Vector2.zero, CursorMode.Auto);
    }

    private IEnumerator LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        asyncLoad.allowSceneActivation = false;

        while (asyncLoad.progress < 0.9F)
        {
            yield return null;
        }

        yield return new WaitForSeconds(8);
        Transitions.current.FadeOut();
        yield return new WaitForSeconds(2);
        asyncLoad.allowSceneActivation = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector2(-10, requiredY), new Vector2(10, requiredY));
    }
}

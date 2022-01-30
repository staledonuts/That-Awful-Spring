using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SwingLine : MonoBehaviour
{
    [SerializeField] private Transform swingHinge;
    private Transform _transform;
    private LineRenderer _swingLine;

    private void Awake()
    {
        _transform = this.transform;
        _swingLine = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        _swingLine.SetPosition(0, swingHinge.position);    
    }

    private void Update()
    {
        _swingLine.SetPosition(1, _transform.position);
    }
}
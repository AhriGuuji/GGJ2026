using System.Collections;
using UnityEngine;

public class Elevator : Recepters
{
    [SerializeField] private Transform endPos;
    [SerializeField] private Transform startPos;
    [SerializeField] private Collider2D buttonCollider;
    [SerializeField] private float timeStep;
    
    private bool _isUp;
    private Vector2 _startPos;
    private Vector2 _endPos;
    private Rigidbody2D _rb;

    private void Start()
    {
        _isUp = false;
        if (startPos == null) startPos = transform;
        
        _startPos = startPos.position;
        _endPos = endPos.position;
        
        _rb = GetComponent<Rigidbody2D>();
    }

    public override void DoSomething()
    {
        if (!_isUp)
        {
            _isUp = true;
            StartCoroutine(Moving(_endPos));
        }
        else if (_isUp)
        {
            _isUp = false;
            StartCoroutine(Moving(_startPos));
        }
    }

    private IEnumerator Moving(Vector2 endPosition)
    {
        Vector2 startPosition = transform.position;
        
        while (startPosition != endPosition)
        {
            _rb.MovePosition(Vector2.Lerp(startPosition, endPosition, timeStep));
            
            startPosition = transform.position;
            
            if (Vector2.Distance(startPosition, endPosition) < 0.1f)
                startPosition = endPosition;
            
            yield return null;
        }
        
        yield return new WaitForSeconds(2.0f);
        
        buttonCollider.enabled = true;
    }
}
using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Trampolim : Recepters
{
    [SerializeField] private Transform endPos;
    [SerializeField] private float timeStep = 0.1f;
    [SerializeField] private Collider2D button;
    private Rigidbody2D _rb;
    private Vector2 _startPos;
    private bool _busy;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _startPos = transform.position;
    }

    public override void DoSomething()
    {
        StartCoroutine(Moving(endPos.position));
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
        
        startPosition = transform.position;
        
        while (startPosition != _startPos)
        {
            _rb.MovePosition(Vector2.Lerp(startPosition, _startPos, timeStep));

            startPosition = transform.position;

            if (Vector2.Distance(startPosition, _startPos) < 0.1f)
                startPosition = _startPos;

            yield return null;
        }
        
        button.enabled = true;
    }
}

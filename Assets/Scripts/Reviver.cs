using System;
using UnityEngine;

public class Reviver : MonoBehaviour
{
    [SerializeField] private Transform initPos;
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = initPos.position;
    }
}

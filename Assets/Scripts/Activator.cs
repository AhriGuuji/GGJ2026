using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField] private List<Recepters> toActivate;
    [SerializeField] private Collider2D collide;
    [SerializeField] private Sprite deactiveSprite;
    [SerializeField] private SpriteRenderer render;
    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (Recepters obj in toActivate)
            obj.DoSomething();
            
        collide.enabled = false; 
        render.sprite = deactiveSprite;
    }
}

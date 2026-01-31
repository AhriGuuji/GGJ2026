using UnityEngine;

public class Floor : Recepters
{
    [SerializeField] private Collider2D collide;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public override void DoSomething()
    {
        spriteRenderer.enabled = true;
        collide.enabled = true;
    }
}

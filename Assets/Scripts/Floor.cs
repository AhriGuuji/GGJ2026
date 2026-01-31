using UnityEngine;

public class Floor : Recepters
{
    [SerializeField] private Collider2D collide;
    public override void DoSomething()
    {
        collide.enabled = true;
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Activator : MonoBehaviour
{
    [SerializeField] private List<Recepters> toActivate;
    [SerializeField] private Collider2D collide;
    [SerializeField] private Sprite deactiveSprite;
    [SerializeField] private SpriteRenderer render;
    [SerializeField] private bool isActivable;
    [SerializeField] private string interactInput = "Interact";
    private InputAction _interact;

    private void Awake()
    {
        _interact = InputSystem.actions.FindAction(interactInput);    
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActivable)
        {
            foreach (Recepters obj in toActivate)
                        obj.DoSomething();
                        
            collide.enabled = false; 
            render.sprite = deactiveSprite;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (isActivable && _interact.WasPressedThisFrame())
        {
            foreach (Recepters obj in toActivate)
                obj.DoSomething();
                        
            collide.enabled = false; 
            render.sprite = deactiveSprite;
        }
    }
}

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
    [SerializeField] private string interactInput2 = "Interact2";
    private InputAction _interact;
    private InputAction _interact2;

    private void Awake()
    {
        _interact = InputSystem.actions.FindAction(interactInput);    
        _interact2 = InputSystem.actions.FindAction(interactInput2);   
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActivable)
        {
            collide.enabled = false; 
            render.sprite = deactiveSprite;
            
            foreach (Recepters obj in toActivate)
                        obj.DoSomething();
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (isActivable && (_interact.WasPressedThisFrame() || _interact2.WasPressedThisFrame()))
        {
            render.sprite = deactiveSprite;
            
            foreach (Recepters obj in toActivate)
                obj.DoSomething();
        }
    }
}

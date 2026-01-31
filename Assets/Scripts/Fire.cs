using UnityEngine;

public class Fire : Recepters
{
    [SerializeField] private GameObject obj;
    public override void DoSomething()
    {
        obj.SetActive(false);
    }
}
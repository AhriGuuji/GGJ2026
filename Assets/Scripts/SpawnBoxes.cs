using UnityEngine;

public class SpawnBoxes : Attack
{
    [SerializeField] private Transform[]  spawnPoints; 
    [SerializeField] private GameObject box;
        
    public override void DoAttack()
    { 
        //PLAY ANIMATION 
        
        foreach (Transform spawnPoint in spawnPoints) 
            Instantiate(box, spawnPoint.position, Quaternion.identity);
    }
}
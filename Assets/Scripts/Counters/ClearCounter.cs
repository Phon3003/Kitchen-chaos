using UnityEngine;

public class ClearCounter : BaseCounter
{
    
    public override void Interact()
    {
        // Debug.Log("Clear Counter");
        Instantiate(kitchenObjectSO.prefab, spawnPoint.transform.position,Quaternion.identity);

    }
}

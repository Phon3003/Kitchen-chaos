using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public abstract class BaseCounter : MonoBehaviour, IInteractable
{
    [SerializeField] protected KitchenObjectSO kitchenObjectSO;
    [SerializeField] protected GameObject spawnPoint;

    public virtual void Interact()
    {
      
    }
}

public class CuttingCouter : BaseCounter
{
    public override void Interact()
    {
        Debug.Log("Add Counter");
    }
}
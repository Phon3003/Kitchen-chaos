using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public abstract class BaseCounter : MonoBehaviour, IInteractable
{
    [SerializeField] protected GameObject holdPoint;

    public virtual void Interact(PlayerController player)
    {
      
    }
}

public class CuttingCouter : BaseCounter
{
    public override void Interact(PlayerController player)
    {
        Debug.Log("Add Counter");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent
{
    bool HasKitchenObject();
    Transform GetHoldPointTransform();
    void SetKitchenObject(KitchenObject newKitchenObject);
}

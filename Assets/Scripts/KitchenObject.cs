using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    IKitchenObjectParent parent;

    public void SetParent(IKitchenObjectParent newParent)
    {
        // Xoá kitchenObject khỏi parent cũ nếu có parent cũ
        if (parent != null)
        {
            parent.SetKitchenObject(null);
        }

        // Đặt kichenObject vào Transofrm của Holdpoint của parent mới
        transform.parent = newParent.GetHoldPointTransform();
        transform.localPosition = Vector3.zero;

        // Gán parent mới cho kitchenObject
        parent = newParent;

        // Gán kitchenObject cho parent mới
        newParent.SetKitchenObject(this);
        Debug.Log("Set parent: " + newParent.ToString());
    }
}

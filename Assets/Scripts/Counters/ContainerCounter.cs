using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;

    public override void Interact(PlayerController player)
    {
        if (player.HasKitchenObject()) {
            // player có kitchenobject, không có tương tác
        } else {
            // player không có kitchenobject, tạo ra kitchenobject, đưa cho player
            GameObject go = Instantiate(kitchenObjectSO.prefab, player.GetHoldPointTransform());
            KitchenObject kitchenObject = go.GetComponent<KitchenObject>();
            kitchenObject.SetParent(player);
        }
    }
}

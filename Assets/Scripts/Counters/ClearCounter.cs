using UnityEngine;

public class ClearCounter : BaseCounter, IKitchenObjectParent
{
    [SerializeField] private KitchenObject kitchenObject;

    public override void Interact(PlayerController player)
    {
        // Debug.Log("Clear Counter");
        if (HasKitchenObject()) {
            // đã có quả cà chua
            if (player.HasKitchenObject()) {
                // player cũng có quả cà chua -> không có tương tác
            } else {
                // player không có quả cà chua -> đưa quả cà chua cho player
                kitchenObject.SetParent(player);
            }
        } else {
            // chưa có quả cà chua
            if (player.HasKitchenObject()) {
                // player có quả cà chua -> đưa cho clear counter
                player.GetKitchenObject().SetParent(this);
            } else {
                // player không có quả cà chua -> không có tương tác
            }
        }
    }

    public bool HasKitchenObject()
    {
        // Kiểm tra xem có kitchenObject hay không
        // Kitchen object = null => chưa có kitchenObject => false
        // Kitchen object != null => đã có kitchenObject => true
        return kitchenObject != null;
    }

    public Transform GetHoldPointTransform()
    {
        return holdPoint.transform;
    }

    public void SetKitchenObject(KitchenObject newKitchenObject)
    {
        kitchenObject = newKitchenObject;
    }
}

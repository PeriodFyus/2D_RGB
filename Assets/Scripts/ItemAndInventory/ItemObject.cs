using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ItemData itemDate;

    private void SetupVisuals()
    {
        if (itemDate == null)
            return;

        GetComponent<SpriteRenderer>().sprite = itemDate.icon;
        gameObject.name = "ItemObject_" + itemDate.itemName;
    }

    public void SetupItem(ItemData _itemData,Vector2 _velocity)
    {
        itemDate = _itemData;
        rb.velocity = _velocity;

        SetupVisuals();
    }

    public void PickupItem()
    {
        if (!Inventory.instance.CanAddItem() && itemDate.itemType == ItemType.Equipment)
        {
            rb.velocity = new Vector2(0, 7);
            PlayerManager.instance.player.fx.CreatePopUpText("Inventory is full");
            return;
        }

        AudioManager.instance.PlaySFX(18, transform);

        Inventory.instance.AddItem(itemDate);
        Destroy(gameObject);
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private int id;
    public int ID {get {return id;} set {id = value;} }

    [SerializeField]
    private ItemType itemType;
    public ItemType ItemType {get { return itemType; }set {itemType = value;} }
    [SerializeField]
    private InventoryManager inventoryManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryManager = InventoryManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnDrop(PointerEventData eventData)
    {
        //Get Item A
        GameObject objA = eventData.pointerDrag;
        ItemDrag itemDragA = objA.GetComponent<ItemDrag>();
        InventorySlot slotA = itemDragA.IconParent.GetComponent<InventorySlot>();
        //Remove Item A from Slot A
        
        if (itemType == ItemType.Shield)
        {
            if (itemDragA.Item.Type != itemType)
                return;
        }
        if (transform.childCount > 0)
        {
            GameObject objB = transform.GetChild(0).gameObject;
            ItemDrag itemDragB = objB.GetComponent<ItemDrag>();

            if (slotA.itemType == ItemType.Shield)
            {
                if (itemDragB.Item.Type != slotA.itemType)
                    return;
            }
            inventoryManager.RemoveItemInBag(slotA.ID);

            //Set Item B on Slot A
            itemDragB.transform.SetParent(itemDragA.IconParent);
            itemDragB.IconParent = itemDragA.IconParent;
            inventoryManager.SaveItemInBag(slotA.ID, itemDragB.Item);

            inventoryManager.RemoveItemInBag(id);
        }
        else
        {
            inventoryManager.RemoveItemInBag(slotA.ID);
        }
        //Set Item A on Slot B
            itemDragA.IconParent = transform;
        inventoryManager.SaveItemInBag(id, itemDragA.Item); 
    }
    

}

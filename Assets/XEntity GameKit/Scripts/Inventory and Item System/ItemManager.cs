using System.Collections.Generic;
using UnityEngine;
using IndicatorsHealth;
namespace XEntity.InventoryItemSystem
{
    //This script contains the all the different item references and different types of item use events.
    //This script must exist in the scene for the saving/loading/item-use system to work properly.
    //NOTE: Only one reference should exist in the scene at once.
    
    public class ItemManager : MonoBehaviour
    {
        public InteractionSettings interactionSettings;

        //Singleton instance of this script.
        public static ItemManager Instance { get; private set; }

        //List of all the item scriptable obects.
        //Either assign the items manually when created or select the item scriptable object > right click > select Add To Item List 
        public List<Item> itemList = new List<Item>();

        private void Awake()
        {
            //Singleton logic
            #region Singleton
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            #endregion

            //Any code in awake should be after the singleton evaluation
        }

        //This function is called when the Use Item button is clicked from one of the inventory items.
        public void UseItem(ItemSlot slot, Indicators indicator) 
        {
            if (slot.IsEmpty) return;
            switch (slot.slotItem.type) 
            {
                default: DefaultItemUse(slot); break;
                case ItemType.ToolOrWeapon: EquipItem(slot); break;
                case ItemType.Placeable: PlaceItem(slot); break;
                case ItemType.Consumeable: ConsumeItem(slot, indicator); break;

            }
        }

        //ADD CUSTOM ITEM TYPE USE METHOD HERE.
        //The custom item use method should take ItemSlot as an argument if you are modifying the item in the slot.
        //Note: This item slot is the slot the item is being held at when the use method is called.

        private void ConsumeItem(ItemSlot slot, Indicators indicator) 
        {
            if (slot.slotItem.itemName == "Apple")
                indicator.foodAmount += 25;
            if(slot.slotItem.itemName == "Pills")
            {
                indicator.smileAmount -= 25;
                indicator.healthAmount += 25;
            }

            Debug.Log("You have consumed " + slot.slotItem.itemName);
            slot.Remove(1);
            indicator.UpdateHealth();
        }

        private void EquipItem(ItemSlot slot) 
        {
            Debug.Log("Equipping " + slot.slotItem.itemName);
        }

        private void PlaceItem(ItemSlot slot) 
        {
            Debug.Log("Placing " + slot.slotItem.itemName);
        }

        private void DefaultItemUse(ItemSlot slot) 
        {
            Debug.Log($"Using {slot.slotItem.itemName}.");
        }


        //Returns the item from itemList at index.
        public Item GetItemByIndex(int index) 
        {
            return itemList[index];
        }

        //Returns the item from the itemList with the name.
        public Item GetItemByName(string name) 
        {
            foreach (Item item in itemList) if (item.itemName == name) return item;
            return null;
        }

        //Returns the index of the passed in item on the itemList.
        //NOTE: Returns -1 if the item does not exist in the list and the item should be added to the list.
        public int GetItemIndex(Item item) 
        {
            for (int i = 0; i < itemList.Count; i++) if (itemList[i] == item) return i;
            return -1;
        }
    } 
}

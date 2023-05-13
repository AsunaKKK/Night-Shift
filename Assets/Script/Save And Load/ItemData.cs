[System.Serializable]
public class ItemData
{
    public string itemName;
    public int quantity;

    public ItemData(string itemName, int quantity)
    {
        this.itemName = itemName;
        this.quantity = quantity;
    }
}

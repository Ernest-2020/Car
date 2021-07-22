using System.Collections.Generic;

public class InventoryModel : IInventoryModel
{

    private readonly List<IItem> _items = new List<IItem>();

    public void EquipItem(IItem item)
    {
        if (_items.Contains(item))
            return;
        _items.Add(item);
    }

    public IReadOnlyList<IItem> GetEquippedItems()
    {
        return _items;
    }

    public void UnEquipItem(IItem item)
    {
        if (!_items.Contains(item))
            return;

        _items.Remove(item);
    }
}

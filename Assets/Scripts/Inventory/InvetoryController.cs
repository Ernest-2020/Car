using System.Collections.Generic;

public class InvetoryController : BaseController, IInvetoryController
{
    private readonly InventoryModel _inventiruModel;
    private readonly InventoryView _inventoryView;
    private readonly ItemsRepository _itemsRepository;
    public InvetoryController(List<ItemConfig> itemConfigs)
    {
        _inventiruModel = new InventoryModel();
        _inventoryView = new InventoryView();
        _itemsRepository = new ItemsRepository(itemConfigs);
    }

    public void SowInventory()
    {
        foreach (var item in _itemsRepository.Items.Values)
            _inventiruModel.EquipItem(item);

        var equippedItems = _inventiruModel.GetEquippedItems();
        _inventoryView.Display(equippedItems);
    }
}

using System;
using System.Collections.Generic;

public class InvetoryController : BaseController, IInvetoryController
{
    private readonly InventoryModel _inventiruModel;
    private readonly InventoryView _inventoryView;
    private readonly ItemsRepository _itemsRepository;


    public Action HidtAction {get; }
    public InvetoryController(List<ItemConfig> itemConfigs)
    {
        _inventiruModel = new InventoryModel();
        _inventoryView = new InventoryView();
        _itemsRepository = new ItemsRepository(itemConfigs);
        SubscribeView();
    }

    public void SowInventory()
    {
        foreach (var item in _itemsRepository.Items.Values)
            _inventiruModel.EquipItem(item);

        var equippedItems = _inventiruModel.GetEquippedItems();
        _inventoryView.Display(equippedItems);
    }

    public void HideInventory()
    {
        _inventoryView.Hide();
        HidtAction?.Invoke();
    }

    private void SubscribeView()
    {
        _inventoryView.Selected += OItemSelected;
        _inventoryView.Deselected += OItemDeselected;
    }

    protected override void OnDispose()
    {
        _inventoryView.Selected -= OItemSelected;
        _inventoryView.Deselected -= OItemDeselected;
        base.OnDispose();
    }

    private void OItemSelected(IItem item)
    {
        _inventiruModel.EquipItem(item);
    }

    private void OItemDeselected(IItem item)
    {
        _inventiruModel.UnEquipItem(item);
    }
}

using System.Collections.Generic;

public class ItemsRepository : BaseController, IItemsRepository
{
    public IReadOnlyDictionary<int, IItem> Items => _itemsMaoById;

    private Dictionary<int, IItem> _itemsMaoById = new Dictionary<int, IItem>();

    public ItemsRepository(List<ItemConfig> itemConfigs)
    {
        PopulateItems(itemConfigs);
    }

    protected override void OnDispose()
    {
        _itemsMaoById.Clear();
    }

    private void PopulateItems(List<ItemConfig> configs)
    {
        foreach(var config in configs)
        {
            if (_itemsMaoById.ContainsKey(config.Id))
                continue;

            _itemsMaoById.Add(config.Id, CreateItem(config));
        }
    }

    private  IItem CreateItem (ItemConfig itemConfig)
    {
        return new Item 
        {
            Id = itemConfig.Id, 
            Info = new Iteminfo { Title = itemConfig.Title } 
        };
    }
}

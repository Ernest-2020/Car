using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRepository : BaseController, IRepository<int, IAbility>
{
    public IReadOnlyDictionary<int, IAbility> Collection => _abilitiesMaoById;

    private Dictionary<int, IAbility> _abilitiesMaoById = new Dictionary<int, IAbility>();

    public AbilityRepository(List<AbilityItemConfig> abilityItemConfigs)
    {
        PopulateItems(abilityItemConfigs);
    }

    protected override void OnDispose()
    {
        _abilitiesMaoById.Clear();
    }

    private void PopulateItems(List<AbilityItemConfig> configs)
    {
        foreach (var config in configs)
        {
            if (_abilitiesMaoById.ContainsKey(config.id))
                continue;

            _abilitiesMaoById.Add(config.id, CreateAbility(config));
        }
    }

    private IAbility CreateAbility(AbilityItemConfig config)
    {
        switch (config.AbilityType)
        {
            case AbilityType.Bomb:

                return new BombAbility(config);
            default:
                Debug.Log($"Not type ability");
                return null;
        }
    }
}

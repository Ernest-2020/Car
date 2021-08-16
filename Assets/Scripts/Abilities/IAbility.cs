using System.Collections.Generic;
using UnityEngine;

public interface IAbility
{
    void Apply(IAbilityActivator activator);
}
public interface IAbilityActivator
{
    GameObject GetViewObject();
}

public interface IAbilitiesController 
{
    void ShowAbilities();
}


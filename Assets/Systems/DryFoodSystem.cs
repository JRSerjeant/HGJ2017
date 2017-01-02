using System;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UnityEngine.UI;

public class DryFoodSystem : IExecuteSystem, IInitializeSystem, ISetPool
{
    Pool _pool;
    Group _dryFoodBarGroup;
    Group _dryFoodButtons;
    public void Initialize()
    {
        _dryFoodButtons = _pool.GetGroup(Matcher.DryFood);
        _dryFoodBarGroup = _pool.GetGroup(Matcher.HumorsBar);

        
    }

    public void Execute()
    {
        foreach (var e in _dryFoodButtons.GetEntities())
        {
            if (e.button.buttonText == "Dry Food")
            {
                if (!e.isEvent)
                {
                    e.gameObject.gameObject.GetComponent<Button>().onClick.AddListener(reduceBlackBile);
                    e.isEvent = true;
                }
            }
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    void reduceBlackBile()
    {
        foreach (var e in _dryFoodBarGroup.GetEntities())
        {
            if (e.humorsBar.name == "Black Bile")
            {
                e.gameObject.gameObject.GetComponent<Scrollbar>().size -= 0.10f;

            }
        }
    }
}

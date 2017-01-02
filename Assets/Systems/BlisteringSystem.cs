using System;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UnityEngine.UI;

public class BlisteringSystem : IExecuteSystem, IInitializeSystem, ISetPool
{
    Pool _pool;
    Group _blisteringBarGroup;
    Group _blisteringButtons;
    public void Initialize()
    {
        _blisteringButtons = _pool.GetGroup(Matcher.Blistering);
        _blisteringBarGroup = _pool.GetGroup(Matcher.HumorsBar);

        
    }

    public void Execute()
    {
        foreach (var e in _blisteringButtons.GetEntities())
        {
            if (e.button.buttonText == "Blistering")
            {
                if (!e.isEvent)
                {
                    e.gameObject.gameObject.GetComponent<Button>().onClick.AddListener(reduceYellowBile);
                    e.isEvent = true;
                }
            }
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    void reduceYellowBile()
    {
        foreach (var e in _blisteringBarGroup.GetEntities())
        {

            if (e.humorsBar.name == "Yellow Bile")
            {
                e.gameObject.gameObject.GetComponent<Scrollbar>().size -= 0.10f;

            }
        }
    }
}

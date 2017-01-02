using System;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UnityEngine.UI;

public class RestSystem : IExecuteSystem, IInitializeSystem, ISetPool
{
    Pool _pool;
    Group _barGroup;
    Group _restButtons;
    public void Initialize()
    {
        _restButtons = _pool.GetGroup(Matcher.Rest);
        _barGroup = _pool.GetGroup(Matcher.HumorsBar);
    }

    public void Execute()
    {
        foreach (var e in _restButtons.GetEntities())
        {
            if (e.button.buttonText == "Rest")
            {
                if (!e.isEvent)
                {
                    e.gameObject.gameObject.GetComponent<Button>().onClick.AddListener(reduceRest);
                    e.isEvent = true;
                }
            }
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    void reduceRest()
    {
        foreach (var e in _barGroup.GetEntities())
        {
            e.gameObject.gameObject.GetComponent<Scrollbar>().size += 0.10f;
        }
    }
}

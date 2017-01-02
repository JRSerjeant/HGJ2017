using System;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UnityEngine.UI;

public class VomitSystem : IExecuteSystem, IInitializeSystem, ISetPool
{
    Pool _pool;
    Group _phlegmBarGroup;
    Group _phlegmButtons;
    public void Initialize()
    {
        _phlegmButtons = _pool.GetGroup(Matcher.Phlegm);
        _phlegmBarGroup = _pool.GetGroup(Matcher.HumorsBar);

        
    }

    public void Execute()
    {
        foreach (var e in _phlegmButtons.GetEntities())
        {
            if (e.button.buttonText == "Vomit")
            {
                if (!e.isEvent)
                {
                    e.gameObject.gameObject.GetComponent<Button>().onClick.AddListener(reducePhlegm);
                    e.isEvent = true;
                }
            }
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    void reducePhlegm()
    {
        foreach (var e in _phlegmBarGroup.GetEntities())
        {

            if (e.humorsBar.name == "Phlegm")
            {
                e.gameObject.gameObject.GetComponent<Scrollbar>().size -= 0.10f;

            }
        }
    }
}

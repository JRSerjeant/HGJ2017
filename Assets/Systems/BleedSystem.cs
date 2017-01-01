using System;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UnityEngine.UI;

public class BleedSystem : IExecuteSystem, IInitializeSystem, ISetPool
{
    Pool _pool;
    Group _bloodBarGroup;
    Group _bleedButtons;
    public void Initialize()
    {
        _bleedButtons = _pool.GetGroup(Matcher.Blood);
        _bloodBarGroup = _pool.GetGroup(Matcher.HumorsBar);

        
    }

    public void Execute()
    {
        foreach (var e in _bleedButtons.GetEntities())
        {
            if (e.button.buttonText == "Bleed")
            {
                if (!e.isEvent)
                {
                    e.gameObject.gameObject.GetComponent<Button>().onClick.AddListener(reduceBlood);
                    e.isEvent = true;
                }
            }
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    void reduceBlood()
    {
        Debug.Log("reduceBlood");
        foreach (var e in _bloodBarGroup.GetEntities())
        {
            if (e.humorsBar.name == "Blood")
            {
                Debug.Log(e.gameObject.gameObject.GetComponent<Scrollbar>().size);
                e.gameObject.gameObject.GetComponent<Scrollbar>().size -= 0.10f;
                Debug.Log(e.gameObject.gameObject.GetComponent<Scrollbar>().size);

            }
        }
    }
}

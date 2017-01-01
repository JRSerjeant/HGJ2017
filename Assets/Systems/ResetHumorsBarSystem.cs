using System;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UnityEngine.UI;

public class ResetBarSystem : ISetPool, IReactiveSystem
{
    Pool _pool;
    Group _group;
    
    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.NewPatient.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        _group = _pool.GetGroup(Matcher.HumorsBar);
        foreach (var e in _group.GetEntities())
        {
            e.gameObject.gameObject.GetComponent<Scrollbar>().size = NewSize();
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public float NewSize()
    {
        return UnityEngine.Random.Range(0f, 1f);
    }
}

﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class CreateHumorsBarSystem : IInitializeSystem, ISetPool, IReactiveSystem
{
    Pool _pool;

    public void Initialize()
    {
        _pool.CreateEntity().AddHumorsBar("pfb_humorsBar", "Blood", Color.red).AddPosition(0,35,0);
        _pool.CreateEntity().AddHumorsBar("pfb_humorsBar", "Black Bile", Color.black).AddPosition(0, 15, 0);
        _pool.CreateEntity().AddHumorsBar("pfb_humorsBar", "Yellow Bile", Color.yellow).AddPosition(0, 55, 0);
        _pool.CreateEntity().AddHumorsBar("pfb_humorsBar", "Phlegm", Color.blue).AddPosition(0, -5, 0);

    }
    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.HumorsBar.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (var e in entities)
        {
            if (!e.hasGameObject)
            {
                GameObject go = UnityEngine.GameObject.Instantiate<GameObject>(Resources.Load(e.humorsBar.prefabName) as GameObject);
                ColorBlock ScrollbarColorBlock = go.GetComponent<Scrollbar>().colors;
                ScrollbarColorBlock.normalColor = e.humorsBar.barColour;
                go.GetComponent<Scrollbar>().colors = ScrollbarColorBlock;

                go.GetComponentInChildren<Text>().text = e.humorsBar.name;

                go.transform.SetParent(GameObject.Find("Canvas").transform, false);
                go.transform.localPosition = new Vector3(e.position.x, e.position.y, e.position.z);
                e.AddGameObject(go);
            }
        }
    }

    

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}

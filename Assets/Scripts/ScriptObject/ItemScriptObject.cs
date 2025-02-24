using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Consumable
}

public enum ItemPropertyType
{
    Hp,
    Energy,
    Mental,
    Speed,
    Attack,
}

[Serializable]
public class ItemProperty
{
    public ItemPropertyType propType;
    public float value;
}

[CreateAssetMenu()]
public class ItemScriptObject : ScriptableObject
{
    public int id;
    public string itemName;
    public ItemType itemType;
    public string description;
    public Sprite icon;
    public GameObject prefab;
    public List<ItemProperty> properties;
}

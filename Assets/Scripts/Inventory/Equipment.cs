using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemClass
{
    Weapon,
    Axe,
    PickAxe,
    Torch,
    Shovel
}
public class Equipment : MonoBehaviour
{
    public ItemClass itemClass;
    public float Damage = 0;
    public int MaxDurability = 100;
    public int CurrDurability;

    private void Start()
    {
        CurrDurability = MaxDurability;
    }
}

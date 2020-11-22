using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LS{

    [CreateAssetMenu(menuName = "Items/Weapon Item")]
public class WeaponItem : Item
{
    public GameObject modelPrefab;
    public bool isUnarmed;
}
}
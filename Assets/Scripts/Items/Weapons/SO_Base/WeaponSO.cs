using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Object/Weapon", fileName ="New Weapon SO")]
public class WeaponSO : ScriptableObject
{
    public int itemID;
    public string weaponName;

    public Sprite sprite;

    public enum AttackType { oneHandSwordSwing, twoHandSwordSwing, spearJab, oneHandAxeSwing, twoHandAxeSwing, projectileShot };
    public AttackType attackType;

    public float baseDamage;
    public float attackCooldown;
}

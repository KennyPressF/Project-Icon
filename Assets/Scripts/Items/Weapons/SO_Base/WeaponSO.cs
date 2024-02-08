using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Object/Weapon", fileName ="New Weapon SO")]
public class WeaponSO : ScriptableObject
{
    [Header("General")]
    public int itemID;
    public string weaponName;
    public bool isRanged;

    [Header("Appearance")]
    public Sprite spriteForUI;
    public Sprite spriteForAnimation;

    public enum AttackType { OneHandSwordSwing, TwoHandSwordSwing, SpearJab, OneHandAxeSwing, TwoHandAxeSwing, ProjectileShot };
    public AttackType attackType;

    [Header("Stats")]
    public float baseDamage;
    public float attackCooldown;

    public GameObject projectilePrefab;
    public float travelSpeed;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] WeaponSO currentWeapon;

    [SerializeField] float attackCooldown;
    bool canAttack;

    [SerializeField] Sprite[] weaponEffectSprites;
    
    Animator animator;
    SpriteRenderer spriteRenderer;
    BoxCollider2D weaponCollider;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        weaponCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        attackCooldown = 0f;
        weaponCollider.enabled = false;
    }

    public void SetWeapon(WeaponSO weaponSO)
    {
        currentWeapon = weaponSO;
    }

    private void Update()
    {
        if(attackCooldown > 0)
        {
            canAttack = false;
            attackCooldown -= Time.deltaTime;
        }
        else
        {
            canAttack = true;
        }
    }

    public void ProcessAttack(InputAction.CallbackContext context)
    {
        if(!canAttack) { return; }

        spriteRenderer.enabled = true;
        weaponCollider.enabled = true;

        switch (currentWeapon.attackType)
        {
            case WeaponSO.AttackType.oneHandSwordSwing:
                spriteRenderer.sprite = weaponEffectSprites[0];
                animator.Play("OneHandedSwordSwing");
                break;

            case WeaponSO.AttackType.twoHandSwordSwing:
                spriteRenderer.sprite = weaponEffectSprites[1];
                animator.Play("TwoHandedSwordSwing");
                break;

            case WeaponSO.AttackType.spearJab:
                spriteRenderer.sprite = weaponEffectSprites[2];
                animator.Play("SpearJab");
                break;

            case WeaponSO.AttackType.oneHandAxeSwing:
                spriteRenderer.sprite = weaponEffectSprites[3];
                animator.Play("OneHandedAxeSwing");
                break;

            case WeaponSO.AttackType.twoHandAxeSwing:
                spriteRenderer.sprite = weaponEffectSprites[4];
                animator.Play("TwoHandedAxeSwing");
                break;

            case WeaponSO.AttackType.projectileShot:
                //Handle Projectiles differently;
                break;

            default:
                Debug.LogError("The PlayerCombat switch statement hit the DEFAULT condition.");
                break;
        }
    }

    public void EndAttack()
    {
        weaponCollider.enabled = false;
        //spriteRenderer.enabled = false;
        animator.Play("NoWeapon");
        attackCooldown = currentWeapon.attackCooldown;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageInterface = collision.GetComponent<IDamageable>();

        if (damageInterface != null)
        {
            damageInterface.LoseHealth(currentWeapon.baseDamage);
        }
    }
}

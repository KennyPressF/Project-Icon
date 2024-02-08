using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] WeaponSO currentWeapon;
    private string weaponAnimationName;

    [SerializeField] float currentDamageOutput;
    [SerializeField] float attackCooldown;
    bool canAttack;

    [SerializeField] Sprite[] weaponEffectSprites;

    [SerializeField] GameObject projectilePrefab;
    private List<GameObject> projectilePool = new List<GameObject>();
    [SerializeField] Transform spawnPoint;

    Animator animator;
    SpriteRenderer spriteRenderer;
    BoxCollider2D weaponCollider;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        weaponCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        attackCooldown = 0f;
        weaponCollider.enabled = false;

        SetWeapon(currentWeapon);
    }

    public void SetWeapon(WeaponSO weaponSO)
    {
        currentWeapon = weaponSO;
        spriteRenderer.sprite = currentWeapon.spriteForAnimation;
        currentDamageOutput = currentWeapon.baseDamage;
        weaponAnimationName = currentWeapon.attackType.ToString();
        if(currentWeapon.isRanged)
        {
            projectilePrefab = currentWeapon.projectilePrefab;
        }
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
        if (!canAttack)
            return;

        spriteRenderer.enabled = true;
        weaponCollider.enabled = true;
        animator.Play(weaponAnimationName);

        if(currentWeapon.isRanged)
        {
            SpawnProjectile();
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
            damageInterface.LoseHealth(currentDamageOutput);
        }
    }

    //Find inactive projectile from pool or add new one to pool
    void SpawnProjectile()
    {
        // Search for an inactive projectile in the pool

        for (int i = 0; i < projectilePool.Count; i++)
        {
            if (!projectilePool[i].activeInHierarchy)
            {
                // Reuse the inactive projectile
                projectilePool[i].transform.position = spawnPoint.position;
                //projectilePool[i].transform.rotation = startingRot;
                projectilePool[i].SetActive(true);
                return;
            }
        }

        // If no inactive projectile is found, instantiate a new one and add it to the pool
        GameObject newProjectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        newProjectile.GetComponent<ProjectileGameObject>().SetValues(transform.up, currentWeapon.travelSpeed, currentDamageOutput);
        //newProjectile.transform.parent = spawnedProjectiles;
        projectilePool.Add(newProjectile);
    }
}

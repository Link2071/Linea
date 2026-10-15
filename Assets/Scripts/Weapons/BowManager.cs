using UnityEngine;

public class BowManager : WeaponManagerSuperclass
{
    private void OnEnable()
    {
        _timer = cooldown;       
    }

    public override void UseWeapon()
    {
        GameObject target = FindClosestEnemy.instance.GetClosestEnemy();
        if (target == null) return;

        GameObject childProjectile = Instantiate(childPrefab, transform.position, Quaternion.identity);
        BowLogic weaponLogic = childProjectile.GetComponent<BowLogic>();
        if (weaponLogic != null)
            weaponLogic.SetTarget(target);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}

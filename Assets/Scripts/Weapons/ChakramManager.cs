using UnityEngine;

public class ChakramManager : WeaponManagerSuperclass
{
    void OnEnable()
    {
        _timer = cooldown;
    }

    override public void UseWeapon()
    {
        GameObject target = FindClosestEnemy.instance.GetClosestEnemy();
        if (target == null) return;

        GameObject childProjectile = Instantiate(childPrefab, transform.position, Quaternion.identity);
        ChakramLogic weaponLogic = childProjectile.GetComponent<ChakramLogic>();
        if (weaponLogic != null)
            weaponLogic.SetTarget(target);
    }

    protected override void Update()
    {
        base.Update();
    }
}

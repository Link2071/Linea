using UnityEngine;

public class SwordManager : WeaponManagerSuperclass
{
    void OnEnable()
    {
        _timer = cooldown;
    }

    override public void UseWeapon()
    {
        GameObject childProjectile = Instantiate(childPrefab, transform);
        childProjectile.GetComponent<SwordLogic>().SetStart(true);
    }

    protected override void Update()
    {
        base.Update();
    }
}
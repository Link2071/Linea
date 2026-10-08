using UnityEngine;

public class ChakramManager : MonoBehaviour, WeaponInterface
{
    [SerializeField] private float cooldown;
    private float _timer;
    [SerializeField] private GameObject chakramPrefab;
    private bool _cooldownElapsed => _timer <= 0;

    void Start()
    {
        _timer = cooldown;
    }

    public void UseWeapon()
    {
        GameObject target = FindClosestEnemy.instance.GetClosestEnemy();
        if (target == null) return;

        GameObject childProjectile = Instantiate(chakramPrefab, transform.position, Quaternion.identity);
        ChakramLogic weaponLogic = childProjectile.GetComponent<ChakramLogic>();
        if (weaponLogic != null)
            weaponLogic.SetTarget(target);
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        if (_cooldownElapsed) {
            UseWeapon();
            _timer = cooldown;
        };
    }
}

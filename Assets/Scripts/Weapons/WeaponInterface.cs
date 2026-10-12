using UnityEngine;

public abstract class WeaponManagerSuperclass : MonoBehaviour
{
    protected float _timer;
    protected bool _cooldownElapsed => _timer <= 0;
    [SerializeField] protected GameObject childPrefab;
    [SerializeField] protected float cooldown;
    protected virtual void Update()
    {
        _timer -= Time.deltaTime;
        if (_cooldownElapsed)
        {
            UseWeapon();
            _timer = cooldown;
        }
    }
    public abstract void UseWeapon();
}

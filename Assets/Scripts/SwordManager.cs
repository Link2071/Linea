using UnityEngine;

public class SwordManager : MonoBehaviour
{
    [SerializeField] private GameObject swordPrefab;
    private float _timer;
    [SerializeField] private float cooldown;
    private bool _cooldownElapsed => _timer <= 0;
    void Start()
    {
        _timer = cooldown;
    }

    public void UseWeapon()
    {
        GameObject childProjectile = Instantiate(swordPrefab, transform);
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        if (_cooldownElapsed)
        {
            UseWeapon();
            _timer = cooldown;
        }
    }
}
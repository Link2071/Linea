using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    public float GetContactDamage()
    {
        return damage;
    }
}

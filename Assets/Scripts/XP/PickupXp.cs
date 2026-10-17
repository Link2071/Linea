using UnityEngine;

public class PickupXp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Xp"))
        {
            XpLogic xpLogic = collision.GetComponent<XpLogic>();
            if (xpLogic == null) return;
            xpLogic.Pickup();
        }
    }
}

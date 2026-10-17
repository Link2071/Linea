using UnityEngine;

public class CollectXp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Xp"))
        {
            XpLogic xpLogic = collision.GetComponent<XpLogic>();
            if (xpLogic == null) return;
            xpLogic.Collect();
        }
    }
}

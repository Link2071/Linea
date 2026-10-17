using UnityEngine;

public class XpLogic : MonoBehaviour
{
    private bool _isCollectible = false;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int xpAmount;

    public void HandleCollision() { PlayerXp.instance.AddXp(xpAmount); }

    public void Pickup()
    {
        if (!_isCollectible){ _isCollectible = true; }
    }

    public void Collect()
    {
        PlayerXp.instance.AddXp(xpAmount);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (_isCollectible)
        {
            moveSpeed = moveSpeed * moveSpeed * moveSpeed;
            float fixedVelocity = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, PlayerController.instance.transform.position, fixedVelocity);
        }
    }
}

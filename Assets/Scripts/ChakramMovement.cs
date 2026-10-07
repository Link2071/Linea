using UnityEngine;

public class ChakramMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 50f;
    private Vector3 _startPos;
    private GameObject _target;
    public void Init(GameObject target)
    {
        _target = target;
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, _target.transform.position) < 0.01) Destroy(gameObject);
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, movementSpeed * Time.deltaTime);   
    }
}

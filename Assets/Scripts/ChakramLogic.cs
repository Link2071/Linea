using UnityEngine;

public class ChakramLogic : MonoBehaviour
{
    private Vector3 _targetPos;
    [SerializeField] private float degreesToRotate = 180;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float lifeTime = 2f; 
    private bool _reachedTarget => Vector3.Distance(transform.position, _targetPos) < 0.01;
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + degreesToRotate * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, _targetPos, moveSpeed * Time.deltaTime);
        if (_reachedTarget) Destroy(gameObject, lifeTime);
    }

    public void SetTarget(GameObject target)
    {
        _targetPos = target.transform.position;
    }
}

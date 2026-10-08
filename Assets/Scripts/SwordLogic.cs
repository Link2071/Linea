using UnityEngine;

public class SwordLogic : MonoBehaviour
{
    [SerializeField] private float degreesToRotate = 45;
    [SerializeField] private float lifeTime = 2f;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 45);
        Destroy(gameObject, lifeTime);
    }
    void Update()
    {
        transform.rotation = Quaternion.Euler( 0, 0, transform.rotation.eulerAngles.z + degreesToRotate * Time.deltaTime);
    }
}


using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, IPoolClient
{
    [HideInInspector] public StartLine startLine;
    [SerializeField] private float speed = 2f;


    void Update()
    {
        transform.position -= speed * Time.deltaTime * transform.right;
    }

    public void Arise(Vector2 position, Quaternion rotation)
    {
        gameObject.SetActive(true);
        transform.SetPositionAndRotation(position, rotation);
    }
    public void Fall()
    {
        gameObject.SetActive(false);
    }

    public void Teleport()
    {
        startLine.Teleport(this);
    }
}

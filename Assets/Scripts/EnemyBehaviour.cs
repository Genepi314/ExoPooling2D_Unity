
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, IPoolClient
{
    [HideInInspector] public StartLine startLine;
    [SerializeField] private float speed = 4f;


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

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}

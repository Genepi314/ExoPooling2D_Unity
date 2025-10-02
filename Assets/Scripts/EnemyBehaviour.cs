using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform startLine;
    [SerializeField] private float speed = 2f;
    private Vector3 position;
    void Start()
    {
        transform.position = startLine.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= speed * Time.deltaTime * transform.right;

    }
}

using Unity.VisualScripting;
using UnityEngine;

public class EndlLIne : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out EnemyBehaviour enemy))
        {
            enemy.Teleport();
        }
    }

}

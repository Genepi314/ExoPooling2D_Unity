using UnityEngine;

public interface IPoolClient
{
    void Arise(Vector2 position, Quaternion rotation);
    void Fall();
}

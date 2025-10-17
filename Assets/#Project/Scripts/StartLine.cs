using System.Collections;
using UnityEngine;

public class StartLine : MonoBehaviour
{
    [SerializeField] private float cooldown = 0.5f;
    [SerializeField] private GameObject prefab;
    private Pool<EnemyBehaviour> pool;
    [SerializeField] private GameObject minY;
    [SerializeField] private GameObject maxY;

    void Start()
    {
        pool = new(gameObject, prefab, 2);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(cooldown);
            EnemyBehaviour enemy = pool.Get(minY.transform.position.y, maxY.transform.position.y); // Ici je récupère le client que Get va générer.
            enemy.startLine = this;
        }
    }

    public void Teleport(EnemyBehaviour enemy)
    {
        pool.Add(enemy);
    }
}

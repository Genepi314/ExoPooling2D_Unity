using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Unity.VisualScripting;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [SerializeField] private GameObject sprite;
    [SerializeField] private CapsuleControler capsContr;
    private List<GameObject> howManyHans = new();
    void Start()
    {
        for (int i = 0; i < capsContr.life; i++)
        {
            Vector2 lifePos = new Vector2(transform.position.x + i, transform.position.y);
            GameObject hanSolo = Instantiate(sprite, lifePos, Quaternion.identity);
            howManyHans.Add(hanSolo);
        }
    }

    public void RemoveLife()
    {
        capsContr.life -= 1;
        Debug.Log($"Il vous reste {capsContr.life} vies.");
    }

}

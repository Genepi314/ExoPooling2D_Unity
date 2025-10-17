using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Unity.VisualScripting;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [SerializeField] private GameObject sprite;
    private List<GameObject> allHans = new();
    [SerializeField] private int hansLife;
    private Color color;
    void Start()
    {
        for (int i = 0; i < hansLife; i++)
        {
            Vector2 lifePos = new Vector2(transform.position.x + i, transform.position.y);
            allHans.Add(Instantiate(sprite, lifePos, Quaternion.identity));
        }
    }

    public void RemoveLife()
    {
        if (hansLife > 0)
        {
            hansLife -= 1;
            Color c = allHans[hansLife].GetComponent<SpriteRenderer>().color;
            c.a = 0;
            allHans[hansLife].GetComponent<SpriteRenderer>().color = c;
        }
        Debug.Log($"Il vous reste {hansLife} vies.");
    }

}

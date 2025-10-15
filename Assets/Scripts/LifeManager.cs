using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Unity.VisualScripting;
using UnityEngine;

// [RequireComponent(typeof(SpriteRenderer))]
public class LifeManager : MonoBehaviour
{
    [SerializeField] private GameObject sprite;
    [SerializeField] private CapsuleControler capsContr;
    private List<GameObject> allHans = new();
    private int hansLife = 3;
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
        if (allHans.Count > 0)
        {
            hansLife -= 1;
            // allHans[hansLife].ChangeAlpha(); 
            
        }
        Debug.Log($"Il vous reste {hansLife} vies.");
    }

}

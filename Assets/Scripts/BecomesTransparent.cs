using Unity.VisualScripting;
using UnityEngine;

public class BecomesTransparent : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    
    public void ChangeAlpha()
    {
        spriteRenderer.color = new Color(0f, 0f, 0f, 0f);
    }
}

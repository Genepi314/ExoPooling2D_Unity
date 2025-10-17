using UnityEngine;
using UnityEngine.InputSystem;

public class CapsuleControler : MonoBehaviour
{
    // Pour les contrôles, of course :
    [SerializeField] private InputActionAsset actions;
    [SerializeField] private float speed;
    [SerializeField] private LifeManager lifePlace;
    private InputAction yAxis;
    private InputAction xAxis;
    [SerializeField] private Camera cam;


    void Awake()
    {
        yAxis = actions.FindActionMap("Capsule").FindAction("moveY");
        xAxis = actions.FindActionMap("Capsule").FindAction("moveX");
    }

    void OnEnable()
    {
        actions.FindActionMap("Capsule").Enable();
    }

    void OnDisable()
    {
        actions.FindActionMap("Capsule").Disable();
    }

    void Update()
    {
        MoveY();
        MoveX();
    }

    private void MoveY()
    {
        if (cam.WorldToScreenPoint(transform.position).y >= Screen.height && yAxis.ReadValue<float>() > 0)
        {
            return;
        }
        else if (cam.WorldToScreenPoint(transform.position).y <= 0f && yAxis.ReadValue<float>() < 0)
        {
            return;
        }
        transform.Translate(0f, yAxis.ReadValue<float>() * speed * Time.deltaTime, 0f);
    }

    private void MoveX()
    {
        if (cam.WorldToScreenPoint(transform.position).x <= 0f && xAxis.ReadValue<float>() < 0)
        {
            return;
        }
        transform.Translate(xAxis.ReadValue<float>() * speed * Time.deltaTime, 0f, 0f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            lifePlace.RemoveLife();
        }
    }
}

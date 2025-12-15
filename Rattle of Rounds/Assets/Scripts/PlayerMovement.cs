using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] InputActionReference moveAction; // arrastra aquí Player/Move

    [HideInInspector]
    Rigidbody2D rb;

    public Vector2 moveDir 
    {
        get;
        private set;        // <- expuesto para otros scripts
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        moveAction.action.Enable();
    }

    void OnDisable()
    {
        moveAction.action.Disable();
    }

    void Update()
    {
        moveDir = moveAction.action.ReadValue<Vector2>().normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveDir * moveSpeed;
    }
}

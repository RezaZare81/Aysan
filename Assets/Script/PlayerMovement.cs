using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Player;

    [SerializeField]
    public Joystick joystick;
    [SerializeField]
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField]
    private int Speed = 400;
    [SerializeField]
    private float moveThreshold = 0.02f;
    private int currentMode = -1; 

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        float moveInput = joystick.Horizontal;
        Vector2 input = new Vector2(moveInput, 0);

        rb.linearVelocity = new Vector2(moveInput * Speed * Time.deltaTime, rb.linearVelocity.y);

        if (moveInput > moveThreshold)
        {
            m_Player.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveInput < -moveThreshold)
        {
            m_Player.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Mathf.Abs(moveInput) > moveThreshold)
        {
            SetMode(3);
        }
        else
        {
            SetMode(1); 
        }
    }

    void SetMode(int newMode)
    {
        if (newMode != currentMode)
        {
            animator.SetInteger("Mode", newMode);
            currentMode = newMode;
        }
    }
}

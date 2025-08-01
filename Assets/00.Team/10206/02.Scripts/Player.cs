using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public Collider2D Collider { get; private set; }
    public Rigidbody2D Rigidbody { get; private set; }
    public Animator Animator { get; private set; }

    public PlayerInput PlayerInput { get; private set; }
    public PlayerMovement PlayerMovement { get; private set; }
    public PlayerAnimation PlayerAnimation { get; private set; }

    private void Awake()
    {
        #region Singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        #endregion
        #region Load Component
        Collider = GetComponent<Collider2D>();
        Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponentInChildren<Animator>();

        PlayerInput = GetComponent<PlayerInput>();
        PlayerMovement = GetComponent<PlayerMovement>();
        PlayerAnimation = GetComponent<PlayerAnimation>();
        #endregion
    }
}

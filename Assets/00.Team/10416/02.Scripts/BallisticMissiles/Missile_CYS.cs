using UnityEngine;
using UnityEngine.UIElements;

public class Missile_CYS : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    private Vector2 moveDir;
    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
     rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        moveDir = player.transform.position - transform.position;
        rigidbody2D.linearVelocity = moveDir * Time.deltaTime * speed;
    }

}

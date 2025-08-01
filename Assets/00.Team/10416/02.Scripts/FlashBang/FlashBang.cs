using UnityEngine;

public class FlashBang : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float checkerSize;

    private void Update()
    {
        if (CheckPlayer()) Debug.Log("Pop");
    }
    private bool CheckPlayer()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, checkerSize, layerMask);
        return collider;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, checkerSize);
    }

}

using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("플레이어가 가시에 부딪힘!");
        }
    }
}

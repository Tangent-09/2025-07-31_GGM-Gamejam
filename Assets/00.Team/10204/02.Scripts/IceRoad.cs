using UnityEngine;

public class IceRoad : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
         PlayerMovement_1 player = other.GetComponent<PlayerMovement_1>();
        if (player != null)
        {
            player.SetOnIce(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerMovement_1 player = other.GetComponent<PlayerMovement_1>();
        if (player != null)
        {
            player.SetOnIce(false); // 수정된 부분
        }
    }
}

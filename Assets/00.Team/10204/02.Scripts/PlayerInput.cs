using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
  public Vector2 MovementInput { get; private set; }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        MovementInput = new Vector2(x, y);
    }
}

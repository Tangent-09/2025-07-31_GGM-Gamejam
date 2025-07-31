using UnityEngine;

public class MyPlayerInput : MonoBehaviour
{
 public Vector2 MovementInput { get; private set; }

    [SerializeField] private bool isReversed = false; 

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 input = new Vector2(x, y);
        if (isReversed)
            input *= -1f;

        MovementInput = input;
    }
    public void SetReverse(bool value)
    {
        isReversed = value;
    }
}

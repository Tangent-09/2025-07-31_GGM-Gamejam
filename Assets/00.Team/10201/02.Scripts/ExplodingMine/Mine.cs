using System;
using Unity.VisualScripting;
using UnityEngine;

public class Mine : MonoBehaviour
{
    #region Variables
    [SerializeField] private SpriteRenderer _spriteRenderer;                              // SpriteRenderer
    [SerializeField] private GameObject _player;                                          // Player/Target(used to get distance)            !!!!!!!!! Remove TempPlayer and allocate actual Player to this !!!!!!!!!!!!

    private float _distance;                                                              // Float Variable to store distance between target and mine
    private Color _tmp;                                                                   // Temporary Color Variable to help adjusting transparency of mine
    #endregion
    #region LifeCycle
    private void Update()
    {
        GetDistance();                                                                    // Get Distance Between two objects
        SetAlpha();                                                                       // Then adjust transparency of Mine depending on how close two object is
    }
    #endregion
    #region Physics
    private void OnTriggerEnter2D(Collider2D collision)                                   // When Touched:
    {
        Explode();                                                                        // Explode BOOM! (should be changed later)
    }
    #endregion
    #region Methods
    private void Explode()                                                                // Method used when player triggers
    {
        Debug.Log("BOOM!");                                                               // [TEMP] log BOOM
        Destroy(gameObject);                                                              // Destroy this
    }

    private void GetDistance()                                                            // Method used to get distance between target and mine
    {
        _distance = Mathf.Abs(_player.transform.position.x - transform.position.x)        // Distance formula: Sum of absolute value of vector x and y substraced by one object's vector x and y
        + Mathf.Abs(_player.transform.position.y - transform.position.y);
    }

    private void SetAlpha()                                                               // Method used to determine alpha value(trasparency) of mine
    {
        _tmp = _spriteRenderer.color;                                                     // Store color of sprite to the temporary Color variable
        _tmp.a = (-_distance + 5) / 50;                                                   // Then change alpha value of temporary Color variable
        _spriteRenderer.color = _tmp;                                                     // Finally, sprite gets color value from temp variable, which has alpha value changed
    }                                                                                     // ^^^^^ This is because you can't directly change alpha value, and needs to change it through color variable
    #endregion
}

using UnityEngine;

public class Hole : MonoBehaviour
{
    #region Variables
    private SpriteRenderer _spriteRenderer;                                   // Sprite Renderer Variable
    private Color _tmp;                                                       // Color Variable to temporary store object's color for visibility adjustment
    #endregion
    #region LifeCycle
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();                     // Gets SpriteRenderer Component from self and store it in variable
    }
    #endregion
    #region Physics
    private void OnTriggerEnter2D(Collider2D collision)                       // When touched (when player falls)
    {
        FallToHole();                                                         // Initiate fall method
    }
    #endregion
    #region Public Methods
    public void Detected()                                                    // Public method to let other objects use to make hole visible
    {
        VisibleHole();                                                        // VisibleHole Method
    }
    #endregion
    #region Methods
    private void VisibleHole()                                                // Method used to make hole visible
    {
        _tmp = _spriteRenderer.color;                                         // Save color of Hole Object's sprite color to temp variable
        _tmp.a = 1;                                                           // Then set alpha value of Color temp variable to make it visible
        _spriteRenderer.color = _tmp;                                         // Save color value of temp variable back to Hole sprite color, making it visible
    }

    private void FallToHole()                                                 // Method used for player triggering the fall
    {
        Debug.Log("How was the fall?");                                       // [TEMP] Welome to the underground! (neeeds to be changed later)
    }
    #endregion
}

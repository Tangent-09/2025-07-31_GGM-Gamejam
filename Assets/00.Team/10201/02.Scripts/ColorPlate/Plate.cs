using System;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] private PlateManager _plateManager; //PlateManager

    [SerializeField] private ColorEnum color; //Colors

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_plateManager.currentColorId == Convert.ToInt32(color)) // if: CorrectOrder
            _plateManager.ColorProgress();                              // Proceed
        else                                                        // if: WrongOrder
            _plateManager.ColorReset();                                 // Reset
    }
}

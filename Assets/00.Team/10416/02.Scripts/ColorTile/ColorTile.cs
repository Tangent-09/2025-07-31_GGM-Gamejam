using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class ColorTile : MonoBehaviour
{
    [SerializeField] private int colorNum;
    private bool canClick;
    private ColorOrderer colorOrderer;
   

    private void Awake()
    {
      colorOrderer = GameObject.Find("Color").GetComponent<ColorOrderer>();
    }
    private void OnMouseEnter()
    {
        canClick = true;
    }//Check if the mouse cursor is over a game object
    private void OnMouseExit()
    {
        canClick = false;
    }

    private void Update()
    {
      if(canClick&&Mouse.current.leftButton.wasPressedThisFrame)//When you press a tile, the answer value changes to your own value.
        {
            colorOrderer.CheckIt = true;
            colorOrderer.InputNum = colorNum;
        }
    }
}


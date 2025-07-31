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
    }//gameObject위에 마우스포인트가 있는지 확인
    private void OnMouseExit()
    {
        canClick = false;
    }

    private void Update()
    {
      if(canClick&&Mouse.current.leftButton.wasPressedThisFrame)//타일을 눌렀을 시 답 값을 본인 값으로 바꿈
        {
            colorOrderer.CheckIt = true;
            colorOrderer.InputNum = colorNum;
        }
    }
}


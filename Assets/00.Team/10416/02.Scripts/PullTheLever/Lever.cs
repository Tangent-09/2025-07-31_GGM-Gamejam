using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lever : MonoBehaviour
{
  public bool IsPooled { get; private set; }
 private LeverGameManager gameManager;
 [SerializeField] private Transform playerChecker;
 [SerializeField] private Vector2 playerCheckerSize;
 [SerializeField] private LayerMask ItisPlayer;
 [SerializeField] private Vector3 setPosition;
    private SpriteRenderer ren;

    private void Start()
    {
     gameManager = GameObject.Find("GameManager").GetComponent<LeverGameManager>();
        ren = GetComponent<SpriteRenderer>();
        IsPooled = false;
    }
    private void FixedUpdate()
    {
       if (CheckPlayer())
      {
       //gameManager.Lever = gameObject;
         if (!IsPooled && Keyboard.current.eKey.wasPressedThisFrame)
         {
                IsPooled = true;
                gameManager.leverCount++;
                ren.color = Color.black;
                Debug.Log(gameManager.leverCount);
         }
      }
    }

    private bool CheckPlayer()//OverlapBox
    {
        Collider2D collider = Physics2D.OverlapBox(playerChecker.position + setPosition, playerCheckerSize, 0,ItisPlayer);
        return collider;
    }
    private void OnDrawGizmos()//Gizmos
    {
        if (playerChecker == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(playerChecker.position + setPosition, playerCheckerSize);
    }
}

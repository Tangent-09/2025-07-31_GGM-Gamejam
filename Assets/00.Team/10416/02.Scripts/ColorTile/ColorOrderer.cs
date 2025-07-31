using UnityEngine;

public class ColorOrderer : MonoBehaviour
{
    private int orderNum;
    public int InputNum { get; set; }
    public bool CheckIt { get; set; }
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
            spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
            NewOrder();
    }
    private void Update()
    {
     if(orderNum == InputNum&&CheckIt)
     {
            Debug.Log("정답");
            NewOrder();
            CheckIt = false;
     }
    else if(CheckIt&& orderNum != InputNum)
    {
            Debug.Log("오답"); CheckIt = false;
     }
    }

    
    private void NewOrder()
    {
             orderNum = Random.Range(0, 4);
             if (orderNum == 0) spriteRenderer.color = Color.red;
             else if (orderNum == 1) spriteRenderer.color = Color.blue;
             else if (orderNum == 2) spriteRenderer.color = Color.green;
             else if (orderNum == 3) spriteRenderer.color = Color.yellow;
    }
}

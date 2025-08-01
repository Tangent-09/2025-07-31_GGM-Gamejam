using UnityEngine;

public class LeverGameManager : MonoBehaviour
{
  public GameObject Lever { get; set; }
    public int leverCount { get; set; }
    private void Start()
    {
     leverCount = 0;
    }

    private void Update()
    {
    
        PoolTheLever();
      
    }

    private void PoolTheLever()
    {
       
        if (leverCount == 3)
        {
            Debug.Log("Clear");
        }

    }

}

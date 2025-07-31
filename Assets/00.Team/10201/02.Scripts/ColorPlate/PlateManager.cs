using UnityEngine;

public class PlateManager : MonoBehaviour
{
    public int currentColorId { get; private set; } // CurrentOrder
    [SerializeField] private int plateCount;        // Count of Plates
    [SerializeField] private GameObject[] plates;   // Plate Index

    public void ColorProgress()                     // if: Right Order
    {
        plates[currentColorId].SetActive(false);    // Disable Plate
        currentColorId++;                           // NextOrder
        if (currentColorId == plateCount)           // if: Every Order is done, Mission Complete
            Debug.Log("Mission Complete");          
    }

    public void ColorReset()                        // if: Wrong Order
    {
        for (int i = currentColorId; i >= 0; i--)   // Enable Every disabled plates
            plates[i].SetActive(true); 
        currentColorId = 0;                         // Order Reset
        Debug.Log("Oh no!");
    }
}

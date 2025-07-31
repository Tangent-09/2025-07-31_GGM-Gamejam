using System.Collections.Generic;
using UnityEngine;
using static ShapeEnum;

public class ShapeMatchManager : MonoBehaviour
{
    public static ShapeMatchManager Instance;

    [SerializeField] private GameObject zone_R;
    [SerializeField] private GameObject zone_G;
    [SerializeField] private GameObject zone_B;

    [SerializeField] private GameObject[] objects;
    private List<(Color color, ObjectColor type)> colors;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        colors = new List<(Color color, ObjectColor type)> {
        (new Color (1, 0.4669811f, 0.7548517f, 1),ObjectColor.Pink), // R
        (new Color (0.2775454f, 0.9339623f, 0.2980392f, 1),ObjectColor.Green), // G
        (new Color (0.1733268f, 0.2145901f, 0.8962264f, 1),ObjectColor.Blue) // B
        };
    }
    private void Start()
    {
        Shuffle(colors);
        ColorShuffle();
    }

    private void ColorShuffle()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            SpriteRenderer spriteRender = objects[i].GetComponent<SpriteRenderer>();
            ShapeObject shapeObject = objects[i].GetComponent<ShapeObject>();

            var colorsList = colors[i];
            spriteRender.color = colorsList.color;
            shapeObject.colorType = colorsList.type;
        }
    }
    private void Shuffle<T>(List<T> colorList)
    {
        for (int i = 0; i < colorList.Count; i++)
        {
            int rand = Random.Range(i, colorList.Count);
            (colorList[i], colorList[rand]) = (colorList[rand], colorList[i]);
        }
    }
    public bool ShapeMatch(ObjectColor shapeObject, ObjectColor shapeZone)
    {
        if (shapeObject == shapeZone)
            return true;
        else
            return false;
    }
}

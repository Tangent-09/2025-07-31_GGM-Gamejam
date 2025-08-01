using UnityEngine;
using ObjectColor = ShapeEnum.ObjectColor;

public class ShapeObject : MonoBehaviour
{
    public ObjectColor colorType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Zone" + collision.gameObject.name);

        if (collision.gameObject.TryGetComponent(out ShapeZone shapeZone))
        {
            if (ShapeMatchManager.Instance.ShapeMatch(colorType, shapeZone.objectColor))
                print("Match!");
            else
                print("MissMatch!");
        }
        else
        {
            print("he don't have component");
        }
    }
}

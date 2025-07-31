using UnityEngine;
using ObjectColor = ShapeEnum.ObjectColor;

public class ShapeObject : MonoBehaviour
{
    public ObjectColor colorType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("감지" + collision.gameObject.name);

        if (TryGetComponent(out ShapeZone shapeZone))
        {
            if (ShapeMatchManager.Instance.ShapeMatch(colorType, shapeZone.objectColor))
                print("매치 성공!");
            else
                print("이 딴 걸 매치 라 고 해???????");
        }
        else
        {
            print("he don't have component");
        }
    }
}

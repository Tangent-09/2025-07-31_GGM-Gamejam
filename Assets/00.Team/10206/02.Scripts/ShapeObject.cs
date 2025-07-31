using UnityEngine;
using ObjectColor = ShapeEnum.ObjectColor;

public class ShapeObject : MonoBehaviour
{
    public ObjectColor colorType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("����" + collision.gameObject.name);

        if (TryGetComponent(out ShapeZone shapeZone))
        {
            if (ShapeMatchManager.Instance.ShapeMatch(colorType, shapeZone.objectColor))
                print("��ġ ����!");
            else
                print("�� �� �� ��ġ �� �� ��???????");
        }
        else
        {
            print("he don't have component");
        }
    }
}

using System.Collections;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public GameObject shadow;
    public GameObject objectRenderer;
    private SpriteRenderer shadowColor;
    private Animator animator;
    private readonly int triggerHash = Animator.StringToHash("Destroy");

    [SerializeField] private float fallingSpeed;
    [SerializeField] private float extraSpeed = 0;

    private float shadowAlpha;
    private float shadowScaleX, shadowScaleY;

    private bool canFalling = true;

    private void Awake()
    {
        shadowColor = shadow.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        shadowScaleX = shadow.transform.localScale.x;
        shadowScaleY = shadow.transform.localScale.y;
        shadowAlpha = shadowColor.color.a;
    }
    private void Start()
    {
        StartCoroutine(ObjectFalling());
        StartCoroutine(ShadowAlpha());
    }
    IEnumerator ObjectFalling()
    {
        while (canFalling)
        {
            float posY = objectRenderer.transform.position.y;

            if (posY <= 0.3f)
            {
                canFalling = false;
                objectRenderer.transform.position = new Vector3(objectRenderer.transform.position.x, -2.7f, objectRenderer.transform.position.z);
                shadowColor.color = new Color(shadowColor.color.r, shadowColor.color.g, shadowColor.color.b, 0);
                StopAllCoroutines();
                break;
            }
            else
            {
                posY -= fallingSpeed + extraSpeed;

                extraSpeed += 0.1f;
                shadowScaleX -= 0.05f;
                shadowScaleY -= 0.05f;

                extraSpeed = Mathf.Clamp(extraSpeed, 0, 3);
                shadowScaleX = Mathf.Clamp(shadowScaleX, 1, 2);
                shadowScaleY = Mathf.Clamp(shadowScaleY, 0.2f, 0.4f);

                shadowColor.color = new Color(shadowColor.color.r, shadowColor.color.g, shadowColor.color.b, shadowAlpha);
                shadow.transform.localScale = new Vector3(shadowScaleX, shadowScaleY, shadow.transform.localScale.z);

                objectRenderer.transform.position = new Vector3(objectRenderer.transform.position.x, posY, objectRenderer.transform.position.z);
            }

            yield return null;
        }

        animator.SetTrigger(triggerHash);
    }
    IEnumerator ShadowAlpha()
    {
        while (canFalling)
        {
            shadowAlpha -= 0.05f;
            shadowAlpha = Mathf.Clamp(shadowAlpha, 0, 1);

            yield return new WaitForSeconds(0.01f);
        }
    }
    public void DestoryAnimationCallBack()
    {
        Destroy(gameObject);
    }
}

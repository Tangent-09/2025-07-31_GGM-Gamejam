using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class WallScale : MonoBehaviour
{
    #region Values
    [SerializeField] private bool isTopWall;
    [SerializeField] private bool isBottomWall;

    [SerializeField] private float changeScaleValue;

    [SerializeField] private bool canScaleChanage = true;
    [SerializeField] private float addScale;
    #endregion
    #region Default Methods
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        CheckPos();
    }
    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
            WallScaleIncreaseChanage(addScale);
    }
    private void FixedUpdate()
    {
        WallScaleDecreaseChanage();
    }
    #endregion
    #region Wall Methods
    private void CheckPos()
    {
        //Wall Pos Check
        float yPos = transform.position.y;
        #region Check Ypos
        if (yPos >= 4)
            isTopWall = true;
        else if (yPos < 0)
            isBottomWall = true;
        #endregion
    }
    private void WallScaleDecreaseChanage()
    {
        //Chanage Wall Scale
        if (!canScaleChanage)
            return;

        Vector3 scale = transform.localScale;
        Vector3 pos = transform.position;
        #region Scale Chanage
        if (isTopWall)
        {
            scale.y += changeScaleValue;
            pos.y -= changeScaleValue / 2f;
        }
        else if (isBottomWall)
        {
            scale.y += changeScaleValue;
            pos.y += changeScaleValue / 2f;
        }
        #endregion
        transform.localScale = scale;
        transform.position = pos;

        GameoverScaleCheck(scale);
    }
    public void WallScaleIncreaseChanage(float addScale)
    {
        StartCoroutine(ScaleIncrease(addScale));
    }
    private void GameoverScaleCheck(Vector3 scale)
    {
        //Gameover check
        if ((isTopWall || isBottomWall) && scale.y >= 5.5f)
        {
            canScaleChanage = false;
            print("GMAE OVER");
        }
    }
    IEnumerator ScaleIncrease(float addScale)
    {
        Vector3 scale = transform.localScale;
        Vector3 pos = transform.position;
        float targetScaleY = scale.y - addScale;

        canScaleChanage = false;

        while (transform.localScale.y > targetScaleY)
        {
            #region Scale Chanage
            if (isTopWall)
            {
                if (scale.y - 0.05f < 0)
                    break;

                scale.y -= 0.05f;
                pos.y += 0.05f / 2f;
            }
            else if (isBottomWall)
            {
                if (scale.y - 0.05f < 0)
                    break;

                scale.y -= 0.05f;
                pos.y -= 0.05f / 2f;
            }
            #endregion

            transform.localScale = scale;
            transform.position = pos;

            yield return null;
        }

        yield return new WaitForSeconds(0.2f);

        canScaleChanage = true;
    }
    #endregion
}

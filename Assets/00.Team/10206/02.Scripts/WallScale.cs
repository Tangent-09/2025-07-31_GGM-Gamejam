using UnityEngine;

public class WallScale : MonoBehaviour
{
    #region Values
    [SerializeField] private bool isTopWall;
    [SerializeField] private bool isBottomWall;
    [SerializeField] private bool isLeftWall;
    [SerializeField] private bool isRightWall;

    [SerializeField] private float changeScaleValue;

    [SerializeField] private bool canScaleChanage = true;
    #endregion
    #region Default Methods
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        CheckPos();
    }

    private void FixedUpdate()
    {
        WallScaleChanage();
    }
    #endregion
    #region Wall Methods
    private void CheckPos()
    {
        //Wall Pos Check
        float yPos = transform.position.y;
        float xPos = transform.position.x;
        #region Check Ypos
        if (yPos >= 4)
            isTopWall = true;
        else if (yPos < 0)
            isBottomWall = true;
        #endregion
        #region Check Xpos
        else if (xPos < 0)
            isLeftWall = true;
        else if (xPos >= 8)
            isRightWall = true;
        #endregion
    }
    private void WallScaleChanage()
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
        else if (isLeftWall)
        {
            scale.x += changeScaleValue;
            pos.x += changeScaleValue / 2f;
        }
        else if (isRightWall)
        {
            scale.x += changeScaleValue;
            pos.x -= changeScaleValue / 2f;
        }
        #endregion
        transform.localScale = scale;
        transform.position = pos;

        GameoverScaleCheck(scale);
    }
    private void GameoverScaleCheck(Vector3 scale)
    {
        //Gameover check
        if ((isTopWall || isBottomWall) && scale.y >= 5.5f)
        {
            print("움직임 중지" + gameObject.name);
            canScaleChanage = false;
        }
        else if ((isLeftWall || isRightWall) && scale.x >= 9f)
        {
            print("움직임 중지" + gameObject.name);
            canScaleChanage = false;
        }
    }
    #endregion
}

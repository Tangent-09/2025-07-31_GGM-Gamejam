using UnityEngine;

public class ZoneChecker : MonoBehaviour
{
     [Header("대상")]
    [SerializeField] private Transform player;           // 플레이어 트랜스폼
    [SerializeField] private Collider2D zoneArea;        // 체크할 구역 (예: 빨간 사각형 콜라이더)

    [Header("증가/감소 속도")]
    [SerializeField] private float increaseSpeed = 0.1f; // 구역 안일 때 증가 속도
    [SerializeField] private float decreaseSpeed = 0.1f; // 구역 밖일 때 감소 속도

    [Header("게이지 설정")]
    [SerializeField] private float maxValue = 50f;       // 최대 게이지 값

    private float currentValue = 0f;
    private bool isCleared = false;

    private void Update()
    {
        Vector2 playerPos2D = new Vector2(player.position.x, player.position.y);

        if (zoneArea.OverlapPoint(playerPos2D))
        {
            currentValue += increaseSpeed;
        }
        else
        {
            currentValue -= decreaseSpeed;
        }

        currentValue = Mathf.Clamp(currentValue, 0f, maxValue);

        if (!isCleared && currentValue >= maxValue)
        {
            isCleared = true;
            Debug.Log("클리어!");
        }

        Debug.Log("현재 값: " + currentValue.ToString("F1"));
    }

    // 외부에서 게이지 값을 가져갈 수 있게 (선택사항)
    public float GetValue()
    {
        return currentValue;
    }
}

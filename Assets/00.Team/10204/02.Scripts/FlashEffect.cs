using UnityEngine;

public class FlashEffect : MonoBehaviour
{
    [SerializeField] private RectTransform flashImage; // 흰색 원 이미지
    [SerializeField] private float expandDuration = 0.5f; // 커지는 시간
    [SerializeField] private float fadeDuration = 1.0f;   // 사라지는 시간
    [SerializeField] private CanvasGroup flashGroup; // 마스크 전체 투명도 조절용

    private Vector3 startScale = Vector3.zero;
    private Vector3 endScale = new Vector3(3000, 3000, 1); // 화면 덮을 정도로 크게

    public void TriggerFlash()
    {
        flashImage.localScale = startScale;
        flashGroup.alpha = 1;
        gameObject.SetActive(true);
        StartCoroutine(FlashRoutine());
    }

    private System.Collections.IEnumerator FlashRoutine()
    {
        float timer = 0f;

        // Step 1: 확대
        while (timer < expandDuration)
        {
            float t = timer / expandDuration;
            flashImage.localScale = Vector3.Lerp(startScale, endScale, t);
            timer += Time.deltaTime;
            yield return null;
        }
        flashImage.localScale = endScale;

        // Step 2: 유지 후 페이드 아웃
        yield return new WaitForSeconds(0.2f);

        timer = 0f;
        while (timer < fadeDuration)
        {
            flashGroup.alpha = 1f - (timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        flashGroup.alpha = 0;
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public CanvasGroup DeadPanelCanvasGroup;
    public CanvasGroup DeadTextCanvasGroup;
    public CanvasGroup DeadButtonCanvasGroup;

    private void Start()
    {
        // 게임 시작 시 패널을 비활성화
        SetCanvasGroupVisible(DeadPanelCanvasGroup, false);
        SetCanvasGroupVisible(DeadTextCanvasGroup, false);
        SetCanvasGroupVisible(DeadButtonCanvasGroup, false);
    }

    public void TriggerIsDead()
    {
        // 패널, 텍스트, 버튼을 순차적으로 페이드 인
        StartCoroutine(FadeCanvasGroup(DeadPanelCanvasGroup, 1, 0.5f)); // 0.5초 동안 패널 페이드 인
        StartCoroutine(FadeCanvasGroup(DeadTextCanvasGroup, 1, 1.0f)); // 1초 후 텍스트 페이드 인
        StartCoroutine(FadeCanvasGroup(DeadButtonCanvasGroup, 1, 1.5f)); // 1.5초 후 버튼 페이드 인
    }

    IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float targetAlpha, float delay)
    {
        yield return new WaitForSeconds(delay); // 지정된 딜레이 후에 시작

        float startAlpha = canvasGroup.alpha;
        float time = 0f;
        float duration = 2f; // 페이드 효과에 걸리는 시간

        while (time < duration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            yield return null; // 다음 프레임까지 기다림
        }

        canvasGroup.alpha = targetAlpha; // 최종 알파 값 설정
    }

    private void SetCanvasGroupVisible(CanvasGroup canvasGroup, bool visible)
    {
        canvasGroup.alpha = visible ? 1 : 0;
        canvasGroup.blocksRaycasts = visible;
        canvasGroup.interactable = visible;
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}

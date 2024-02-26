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
        // ���� ���� �� �г��� ��Ȱ��ȭ
        SetCanvasGroupVisible(DeadPanelCanvasGroup, false);
        SetCanvasGroupVisible(DeadTextCanvasGroup, false);
        SetCanvasGroupVisible(DeadButtonCanvasGroup, false);
    }

    public void TriggerIsDead()
    {
        // �г�, �ؽ�Ʈ, ��ư�� ���������� ���̵� ��
        StartCoroutine(FadeCanvasGroup(DeadPanelCanvasGroup, 1, 0.5f)); // 0.5�� ���� �г� ���̵� ��
        StartCoroutine(FadeCanvasGroup(DeadTextCanvasGroup, 1, 1.0f)); // 1�� �� �ؽ�Ʈ ���̵� ��
        StartCoroutine(FadeCanvasGroup(DeadButtonCanvasGroup, 1, 1.5f)); // 1.5�� �� ��ư ���̵� ��
    }

    IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float targetAlpha, float delay)
    {
        yield return new WaitForSeconds(delay); // ������ ������ �Ŀ� ����

        float startAlpha = canvasGroup.alpha;
        float time = 0f;
        float duration = 2f; // ���̵� ȿ���� �ɸ��� �ð�

        while (time < duration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            yield return null; // ���� �����ӱ��� ��ٸ�
        }

        canvasGroup.alpha = targetAlpha; // ���� ���� �� ����
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

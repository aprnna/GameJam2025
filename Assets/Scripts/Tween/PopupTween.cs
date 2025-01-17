using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PopupTween : MonoBehaviour
{
    [Header("Animation Settings")]
    public float animationDuration = 0.5f;
    public Vector3 initialScale = new Vector3(0.5f, 0.5f, 0.5f);
    public Vector3 finalScale = Vector3.one;

    [Header("Fade Settings")]
    public CanvasGroup canvasGroup;

    [Header("Background Settings")]
    public GameObject background;
    public float backgroundFadeDuration = 0.5f;
    public Color backgroundColor = new Color(0, 0, 0, 0.5f); // Black with 50% transparency

    private void Awake()
    {
        // Ensure the popup and background are invisible initially
        if (canvasGroup != null)
            canvasGroup.alpha = 0;

        transform.localScale = initialScale;
    }

    public void ShowPopup()
    {
        // Animate background fade-in
        background.SetActive(true);
        var bgRenderer = background.GetComponent<UnityEngine.UI.Image>();
        if (bgRenderer != null)
        {
            bgRenderer.DOColor(backgroundColor, backgroundFadeDuration).SetEase(Ease.OutQuad);
        }

        // Enable the popup GameObject if it's not active
        gameObject.SetActive(true);

        // Animate scale and fade-in
        transform.localScale = initialScale;
        transform.DOScale(finalScale, animationDuration).SetEase(Ease.OutBack);

        if (canvasGroup != null)
        {
            canvasGroup.DOFade(1, animationDuration).SetEase(Ease.OutQuad);
        }
    }

    public void HidePopup()
    {
        // Animate background fade-out
        var bgRenderer = background.GetComponent<UnityEngine.UI.Image>();
        if (bgRenderer != null)
        {
            bgRenderer.DOColor(new Color(backgroundColor.r, backgroundColor.g, backgroundColor.b, 0), backgroundFadeDuration).SetEase(Ease.InQuad).OnComplete(() =>
            {
                background.SetActive(false);
            });
        }

        // Animate popup scale and fade-out
        transform.DOScale(initialScale, animationDuration).SetEase(Ease.InBack);

        if (canvasGroup != null)
        {
            canvasGroup.DOFade(0, animationDuration).SetEase(Ease.InQuad).OnComplete(() =>
            {
                // Deactivate GameObject after animation completes
                gameObject.SetActive(false);
            });
        }
        else
        {
            // If no canvasGroup, deactivate GameObject directly after scale animation
            DOVirtual.DelayedCall(animationDuration, () => gameObject.SetActive(false));
        }
    }
}

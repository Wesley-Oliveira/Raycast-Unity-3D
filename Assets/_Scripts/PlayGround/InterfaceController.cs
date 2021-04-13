using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using TMPro;

public class InterfaceController : MonoBehaviour
{
    private bool titleOpened = true;
    public RectTransform titleTransform;
    public TextMeshProUGUI titleText;
    public CanvasGroup menuGroup;
    public RectTransform menuGroupTransform;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (titleOpened)
                CloseTitle();
            else
                OpenTitle();
        }
    }

    private void OpenTitle()
    {
        titleOpened = true;
        titleTransform.DOAnchorPosY(-20, 0.4f, true).SetEase(Ease.OutBack);
        titleText.DOColor(Color.black, 0.4f);

        menuGroup.DOFade(1f, 0.4f);
        menuGroupTransform.DOAnchorPosY(-80, 0.4f, true).SetEase(Ease.OutBack);
        menuGroup.blocksRaycasts = true;
        menuGroup.interactable = true;
    }

    private void CloseTitle()
    {
        titleOpened = false;
        titleTransform.DOAnchorPosY(50, 0.4f, true).SetEase(Ease.OutBack);
        titleText.DOColor(Color.clear, 0.4f);

        menuGroup.DOFade(0f, 0.4f);
        menuGroupTransform.DOAnchorPosY(0, 0.4f, true).SetEase(Ease.OutBack);
        menuGroup.blocksRaycasts = false;
        menuGroup.interactable = false;
    }
}

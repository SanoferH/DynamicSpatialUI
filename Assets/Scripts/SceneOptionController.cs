using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class SceneOptionController : MonoBehaviour
{
    [SerializeField] private GameObject BGImage;
    [SerializeField] private GameObject ScrollViewUI;
    [SerializeField] private GameObject SceneOptionsCanvas;
    void Start()
    {
        ScrollViewUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Button]
    public void ShowImageNotification()
    {
        BGImage.SetActive(true);
        LeanTween.scale(BGImage, new Vector3(1.0f, 0.25f, 1.0f), 1.0f).setEaseOutBounce();
    }

    [Button]
    public void HideImageNotification()
    {
        LeanTween.scale(BGImage, new Vector3(0.0f, 0.0f, 0.0f), 0.75f).setEaseOutQuart();
    }

    [Button]
    public void ShowScrollUI()
    {
        BGImage.SetActive(true);
        LeanTween.moveLocalY(SceneOptionsCanvas, -4.5f, 1.0f).setEaseInOutBack();
        LeanTween.scale(BGImage, new Vector3(1.0f, 1.0f, 1.0f), 1.0f).setOnComplete(ScrollUIActivate).setEaseInOutBack();
    }

    private void ScrollUIActivate()
    {
        ScrollViewUI.SetActive(true);
        LeanTween.alphaCanvas(ScrollViewUI.GetComponent<CanvasGroup>(), 1.0f,0.2f);
    }
    [Button]
    public void HideScrollUI()
    {
        //BGImage.SetActive(false);
        LeanTween.scale(BGImage, new Vector3(1.0f, 0.25f, 1.0f), 1.0f);
        LeanTween.moveLocalY(SceneOptionsCanvas, -2.086f, 1.5f).setEaseInOutBack();
        LeanTween.alphaCanvas(ScrollViewUI.GetComponent<CanvasGroup>(), 0.0f, 0.2f).setOnComplete(ScrollUIDeActivate);
        
    }
    private void ScrollUIDeActivate()
    {
        ScrollViewUI.SetActive(false);
    }
}

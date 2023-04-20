using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class UIAnimationController : MonoBehaviour
{
    [SerializeField] private GameObject icon;
    [SerializeField] private GameObject iconBorder;
    [Range(0.1f, 1.0f)]
    public float PingPongSpeed = 0.7f;
    public bool canCallGazeHover = false;
    public bool canCallGazeUnhover = false;
    public Color iconColor;
    // Start is called before the first frame update
    void Start()
    {
        IconBorderAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        if (canCallGazeHover)
        {
            IconGazeHover();
            
        }
        if (canCallGazeUnhover)
        {
            IconGazeUnHover();
            
        }
    }
    
    private void IconBorderAnimation()
    {
        LeanTween.scale(iconBorder, new Vector3(0.9f,0.9f,0.9f), PingPongSpeed).setLoopPingPong().setOnUpdate((value) =>
        {
            iconBorder.GetComponent<Image>().fillAmount = value;
            iconBorder.GetComponent<Image>().color = Color.Lerp(iconColor, Color.white, 0.2f);
        });
       
    }


    private void IconBorderAnimationStop()
    {
        LeanTween.cancel(iconBorder);
        LeanTween.scale(iconBorder, new Vector3(1.0f, 1.0f, 1.0f), 0.2f).setOnUpdate((value) =>
        {
            iconBorder.GetComponent<Image>().fillAmount = value;
            iconBorder.GetComponent<Image>().color = Color.Lerp(Color.white, iconColor, 0.2f);
        });
     
    }

    private void IconNormal()
    {
        LeanTween.cancel(icon);
        LeanTween.scale(icon, new Vector3(0.5f, 0.5f, 0.5f), 0.2f).setOnUpdate((value) =>
        {
            icon.GetComponent<Image>().fillAmount = value;
            icon.GetComponent<Image>().color = Color.Lerp(Color.white, iconColor, 0.2f);
        });
    }

    private void IconAnimation()
    {
        LeanTween.scale(icon, new Vector3(0.6f, 0.6f, 0.6f), PingPongSpeed).setLoopPingPong().setOnUpdate((value) =>
        {
            icon.GetComponent<Image>().fillAmount = value;
            icon.GetComponent<Image>().color = Color.Lerp(iconColor, Color.white, 0.2f);
        });
    }
    [Button]
    public void IconGazeHover()
    {
        IconBorderAnimationStop();
        IconAnimation();
        canCallGazeHover = false;

    }
    [Button]
    public void IconGazeUnHover()
    {
        IconBorderAnimation();
        IconNormal();
        canCallGazeUnhover = false;
    }
}

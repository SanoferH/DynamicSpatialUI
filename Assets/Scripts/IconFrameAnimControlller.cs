using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using PathCreation;

public class IconFrameAnimControlller : MonoBehaviour
{

    public float targetDist =2;
    public PathCreator pathCreator;
    public float speed = 5.0f;
    private float distanceTravelled = 0;
    private bool reachedNear = false;
    [SerializeField] private Transform UserPosition;

    [SerializeField] private Animator iconFrameAnimator;
    [SerializeField] private GameObject icon;
    [SerializeField] private GameObject iconMessage;
    [SerializeField] private CanvasGroup backGroundImage;
    [SerializeField] private RectTransform canvasBG;
    public float fadeTime = 0.5f;
    public float fadeAlpha = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        DefaultAnimation();

        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(UserPosition.position, transform.position);
        Debug.Log(dist);

        if (dist <= 7.5f)
        {
            Approaching();

            if (dist <= 6.0f)
            {
                ReachedNear();
            }

        }
    }

   

    IEnumerator ShowMessage()
    {
        while (distanceTravelled < targetDist)
        {
            distanceTravelled += speed * Time.deltaTime; // or whatever to get the speed you like
            distanceTravelled = Mathf.Clamp(distanceTravelled, 0f, targetDist);
            iconMessage.transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            Debug.Log(distanceTravelled);
            yield return null;
        }
    }

    [Button]
    public void DefaultAnimation()
    {
        

        if (!reachedNear)
        {
            iconFrameAnimator.SetBool("Animate", true);
            iconFrameAnimator.SetBool("GazeSelect", false);
            LeanTweenExt.LeanScale(icon, new Vector3(1.0f, 1.0f, 1.0f), 0.5f);

            LeanTweenExt.LeanScale(iconMessage, new Vector3(0.0f, 0.0f, 0.0f), 0.2f);
            distanceTravelled = 0;
        }
        
    }
    [Button]
    public void GazeHovered()
    {
        iconFrameAnimator.SetBool("Animate", false);
        iconFrameAnimator.SetBool("GazeSelect", true);
        LeanTweenExt.LeanScale(icon, new Vector3(1.5f, 1.5f, 1.5f), 0.5f);
        
    }

    [Button]
    public void Approaching()
    {
        LeanTweenExt.LeanScale(iconMessage, new Vector3(1.0f, 1.0f, 1.0f), 0.5f);
        StartCoroutine(ShowMessage());
    }
    [Button]
    public void ReachedNear()
    {
        reachedNear = true;
        LeanTweenExt.LeanMoveLocalY(iconMessage, -4.5f, 1.0f).setEaseOutQuart();
       // LeanTweenExt.LeanAlpha(backGroundImage, 0.5f, 0.25f);
        LeanTween.alphaCanvas(backGroundImage, fadeAlpha, fadeTime);
        LeanTween.scale(canvasBG, new Vector2(0.015f, 0.03f), fadeTime);
    }

}

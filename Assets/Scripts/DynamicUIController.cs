using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicUIController : MonoBehaviour
{
    [SerializeField] private SceneOptionController sceneOptionController;
    [SerializeField] private UIAnimationController iconUIAnimationController;
    [SerializeField] private Transform UserPosition;
    private bool _notificationShown = false;
    private bool _scrollUIShown = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(UserPosition.position, transform.position);
        Debug.Log(dist);
        if (dist <= 7.5f)
        {
            if (!_notificationShown)
            {
                NearToPersonalSpace();
            }
            
            if (dist <= 6.0f)
            {
                if (!_scrollUIShown)
                {
                    InsidePersonalSpace();
                }

            }
            else
            {
                if (_scrollUIShown)
                {
                    OutsidePersonalSpace();
                }
            }
            
        }
        else
        {
            if (_notificationShown)
            {
                FarFromPersonalSpace();
            }
        }
        
       
    }

    public void NearToPersonalSpace()
    {
        sceneOptionController.ShowImageNotification();
        _notificationShown = true;


    }

    public void FarFromPersonalSpace()
    {
        sceneOptionController.HideImageNotification();
        _notificationShown = false;

    }

    public void InsidePersonalSpace()
    {
        sceneOptionController.ShowScrollUI();
        _scrollUIShown = true;
    }
    public void OutsidePersonalSpace()
    {
        sceneOptionController.HideScrollUI();
        _scrollUIShown = false;
    }


}

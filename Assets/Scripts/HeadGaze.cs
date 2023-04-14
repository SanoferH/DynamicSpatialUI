using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadGaze : MonoBehaviour
{
    [SerializeField] private IconFrameAnimControlller iconController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction, Color.green);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider.GetComponent<RedIconIdentifier>())
            {
                iconController.GazeHovered();
            }
            else
            {
                iconController.DefaultAnimation();
            }
        }

        /*
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,
                Mathf.Infinity))
        {
            if (hit.collider.GetComponent<RedIconIdentifier>())
            {
                iconController.GazeHovered();
            }
            else
            {
                iconController.DefaultAnimation();
            }
        }
        */
    }
}

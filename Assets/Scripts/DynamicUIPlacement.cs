using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicUIPlacement : MonoBehaviour
{
    [SerializeField] private GameObject DynamicUIObject;
    void Start()
    {
        DynamicUIObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReplaceWithDynamicUI()
    {
        GameObject Anchor = GameObject.FindGameObjectWithTag("Anchor");
        DynamicUIObject.SetActive(true);
        if (Anchor != null)
        {
            // DynamicUIObject.transform.position = Anchor.transform.position;
            DynamicUIObject.transform.position = new Vector3(Anchor.transform.position.x, 2.0f, Anchor.transform.position.z);
        }
            
    }
}

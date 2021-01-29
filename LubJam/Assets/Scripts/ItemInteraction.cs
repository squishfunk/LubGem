using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    private Item itemBeingSelected;

    [SerializeField]
    private LayerMask layerMask;

    private bool HasItemTargetted;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SelectItem();
    }


    private void SelectItem()
    {

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 2f, Color.red);

        RaycastHit hitInfo;
      
        if (Physics.Raycast(ray, out hitInfo, 2f));
        {
            var selection = hitInfo.transform;
            if (selection == null) return;

            if (selection.GetComponent<Item>() == null) return;

            else if (selection.GetComponent<Item>() != null)
            {
                Debug.Log("Dzieje się");
            }
        }

        //    var hitItem = hitInfo.collider.GetComponent<Item>();

        //    if (hitItem == null)
        //    {
        //        itemBeingSelected = null;
        //    }

        //    else if (hitItem != null && hitItem != itemBeingSelected)
        //    {
        //        itemBeingSelected = hitItem;
        //        Debug.Log("Znalezione");
        //    }

        //    else itemBeingSelected = null;
        //}
    }
}

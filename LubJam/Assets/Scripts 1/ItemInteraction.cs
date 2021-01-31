using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    private PickUpScript itemBeingSelected;

    [SerializeField]
    private LayerMask layerMask;

    public bool CanBePicked;

    [SerializeField]
    private GameObject pickUpPanel;

    // Start is called before the first frame update
    void Start()
    {
        pickUpPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SelectItem();
    }

    private void SelectItem()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 3f, Color.red);

        RaycastHit hitInfo;
      
        if (Physics.Raycast(ray, out hitInfo, 3f));
        {
            var selection = hitInfo.transform;
            if (selection == null)
            {
                CanBePicked = false;
                pickUpPanel.SetActive(false);
                return;
            }
    
            else if (selection.GetComponent<PickUpScript>() != null)
            {
                CanBePicked = true;
                pickUpPanel.SetActive(true);
                Debug.Log("Dzieje się");
            }
        }

    }
}

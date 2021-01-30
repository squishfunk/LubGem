using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{

    [SerializeField]
    private Camera camera;

    private QuestGiverScript npc;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private GameObject questPanel;

    // Start is called before the first frame update
    void Start()
    {
        questPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SelectNPC();
    }

    private void SelectNPC()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 4f, Color.red);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 4f)) ;
        {
            var selection = hitInfo.transform;
            if (selection == null)
            {
                questPanel.SetActive(false);
                return;
            }

            else if (selection.GetComponent<QuestGiverScript>() != null)
            {
                Debug.Log("NPC możliwy do zagadania");
                questPanel.SetActive(true);
               
            }
        }

    }
}

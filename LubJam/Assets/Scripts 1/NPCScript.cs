using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{

    public HandlingQuests handlingQuests;


    // Start is called before the first frame update
    void Start()
    {
        handlingQuests = FindObjectOfType<HandlingQuests>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<PickUpScript>();

        if (item == null) return;
        else
        {
            if (other.gameObject == handlingQuests.quest.itemToFound)
                Debug.Log("Znalezione!");
            else
            {
                Debug.Log("Jakieś barachło");
            }
        }
    }
}

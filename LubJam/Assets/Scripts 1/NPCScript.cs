using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{

    public HandlingQuests handlingQuests;


<<<<<<< Updated upstream
=======
    public GameObject cokolwiek;

>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            if (other.gameObject == handlingQuests.quest.itemToFound)
=======
            if (other.gameObject.name == handlingQuests.quest.itemToFound.name + "(Clone)")
>>>>>>> Stashed changes
                Debug.Log("Znalezione!");
            else
            {
                Debug.Log("Jakieś barachło");
<<<<<<< Updated upstream
            }
        }
=======
                StartCoroutine(BadItemCOroutine());
                Destroy(item);
            }
        }
    }


    IEnumerator BadItemCOroutine()
    {
        cokolwiek.SetActive(true);
        yield return new WaitForSeconds(3f);
        cokolwiek.SetActive(false);
>>>>>>> Stashed changes
    }
}

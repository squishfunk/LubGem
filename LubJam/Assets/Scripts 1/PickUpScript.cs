using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public Transform PlayerHands;

    public ItemInteraction itemInteraction;


    private void Awake()
    {   
    }

    private void OnMouseDown()
    {
        if (!itemInteraction.CanBePicked) return;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = PlayerHands.position;
        this.transform.parent = GameObject.Find("PlayerHands").transform;
    }

    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }

}

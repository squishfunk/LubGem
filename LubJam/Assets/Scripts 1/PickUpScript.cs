﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public Transform PlayerHands;

    public ItemInteraction itemInteraction;

    private Rigidbody rg;

    public float force;

    public bool IsPicked = false;


    private void Awake()
    {

        rg = GetComponent<Rigidbody>();
        PlayerHands = GameObject.FindGameObjectWithTag("PlayerHands").transform;
        itemInteraction = FindObjectOfType<ItemInteraction>();
        force = 5f;
    }



    private void Update()
    {
        if (itemInteraction.CanBePicked && Input.GetMouseButtonDown(1) && IsPicked)
        {
         //   this.gameObject.GetComponent<Collider>().enabled = true;
            this.transform.parent = null;
            rg.isKinematic = false;
            rg.useGravity = true;
            rg.AddForce(PlayerHands.forward * force, ForceMode.Impulse);
         
        }
    }

    private void OnMouseDown()
    {
        if (!itemInteraction.CanBePicked) return;
        else
        {
            IsPicked = true;
             // this.gameObject.GetComponent<Collider>().enabled = false;
            // this.gameObject.GetComponent<Collider>().isTrigger = true;
            this.transform.position = PlayerHands.position;
            this.transform.parent = GameObject.Find("PlayerHands").transform;
            rg.velocity = Vector3.zero;
            rg.useGravity = false;
            rg.isKinematic = true;



        }       
    }

    private void OnMouseUp()
    {
        IsPicked = false;
        //this.gameObject.GetComponent<Collider>().isTrigger = false;
      //  this.gameObject.GetComponent<Collider>().enabled = true;
        this.transform.parent = null;
        rg.useGravity = true;
        rg.isKinematic = false;
      //  this.gameObject.GetComponent<Collider>().enabled = true;

    }



}

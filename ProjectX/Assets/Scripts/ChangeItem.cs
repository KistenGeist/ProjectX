using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeItem : MonoBehaviour
{
    private Inventory inventory;
    private CircleCollider2D umbrella;
    private GameObject Player;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        umbrella = GameObject.FindGameObjectWithTag("Umbrella").GetComponent<CircleCollider2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        umbrella.enabled = false;
    }
    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (inventory.isFull[0])
            {
                Player.GetComponent<PlayerThrowDagger>().hasDagger = true;
                Player.GetComponent<PlayerThrowDagger>().DaggerGFX.enabled = true;
                Player.GetComponent<PlayerThrowDagger>().CanThrow = true;

                Player.GetComponent<PlayerHoldUmbrella>().UmbrellaToHold.enabled = false;

                umbrella.enabled = false;
            } 
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (inventory.isFull[1])
            {
                Player.GetComponent<PlayerThrowDagger>().ResetDagger();
                Player.GetComponent<PlayerThrowDagger>().hasDagger = false;
                Player.GetComponent<PlayerThrowDagger>().DaggerGFX.enabled = false;
                Player.GetComponent<PlayerThrowDagger>().CanThrow = false;

                Player.GetComponent<PlayerHoldUmbrella>().UmbrellaToHold.enabled = true;

                umbrella.enabled = true;
            }
        }
    }
}

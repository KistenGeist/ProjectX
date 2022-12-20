using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for(int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    //Item can be picked up and added to inventory
                    inventory.isFull[i] = true;
                    //Instantiate(itemButton, inventory.slots[i].transform, false);
                    if (GameObject.Find("Dagger PickUp") != null && itemButton == GameObject.Find("Dagger PickUp").GetComponent<PickUp>().itemButton)
                    {
                        GameObject newObject = Instantiate(itemButton, inventory.slots[i].transform, false) as GameObject;  // instatiate the object
                        newObject.transform.localScale = new Vector3(2, 2, 2);
                    }

                    if (GameObject.Find("Umbrella PickUp") != null && itemButton == GameObject.Find("Umbrella PickUp").GetComponent<PickUp>().itemButton)
                    {
                        GameObject newObject = Instantiate(itemButton, inventory.slots[i].transform, false) as GameObject;  // instatiate the object
                        newObject.transform.localScale = new Vector3(3, 3, 3);
                    }
                    /*if (GameObject.Find("Dagger PickUp") != null && itemButton == GameObject.Find("Dagger PickUp").GetComponent<PickUp>().itemButton)
                    {
                        GameObject Player = GameObject.FindGameObjectWithTag("Player");
                        Player.GetComponent<PlayerThrowDagger>().hasDagger = true;
                        Player.GetComponent<PlayerThrowDagger>().DaggerGFX.enabled = true;
                        Player.GetComponent<PlayerThrowDagger>().CanThrow = true;
                    }*/

                    /*if (GameObject.Find("Umbrella PickUp") != null && itemButton == GameObject.Find("Umbrella PickUp").GetComponent<PickUp>().itemButton)
                    {
                        GameObject Player = GameObject.FindGameObjectWithTag("Player");
                        Player.GetComponent<PlayerHoldUmbrella>().UmbrellaToHold.enabled = true;
                    }*/

                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}

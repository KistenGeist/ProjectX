using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoldUmbrella : MonoBehaviour
{
    [SerializeField] public SpriteRenderer UmbrellaToHold;
    // Start is called before the first frame update
    void Start()
    {
        UmbrellaToHold.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

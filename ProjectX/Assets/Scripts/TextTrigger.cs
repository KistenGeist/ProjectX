using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTrigger : MonoBehaviour
{
    public GameObject UiObject;
    public GameObject square;

    // Start is called before the first frame update
    void Start()
    {
        UiObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UiObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        UiObject.SetActive(false);
    }
}

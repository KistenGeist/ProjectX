using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerThrowDagger : MonoBehaviour
{
    [SerializeField] GameObject DaggerPrefab;
    [SerializeField] public SpriteRenderer DaggerGFX;
    [SerializeField] Transform Dagger;

    [Range(0f, 100f)]
    [SerializeField] float DaggerPower;
    
    public bool CanThrow = true;
    public bool CanTeleport = false;

    Dagger dagger;

    public bool hasDagger = false;

    private void Start()
    {
        DaggerGFX.enabled = false;
        CanTeleport = false;
        CanThrow = false;
    }

    private void Update()
    {
        if (hasDagger)
        {
            if (Input.GetMouseButton(0) && CanThrow)
            {
                ThrowDagger();
                CanThrow = false;
            }
            else
            {
                if (CanTeleport)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        TeleportToDagger();
                        ResetDagger();
                    }
                    else if (Input.GetMouseButton(1))
                    {
                        ResetDagger();
                    }
                }
                else
                {
                    if (!CanThrow)
                        CanThrow = true;
                }
            }
        }
    }

    public void ResetDagger()
    {
        if (dagger != null) Object.Destroy(dagger.gameObject);

        CanTeleport = false;
        CanThrow = true;
        DaggerGFX.enabled = true;
    }

    void ThrowDagger()
    {
        float DaggerSpeed = DaggerPower;

        float angle = Utility.AngleTowardsMouse(Dagger.position);
        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

        dagger = Instantiate(DaggerPrefab, Dagger.position, rotation).GetComponent<Dagger>();
        dagger.DaggerVelocity = DaggerSpeed;

        CanThrow = false;
        CanTeleport = true;
        DaggerGFX.enabled = false;
    }

    public void TeleportToDagger()
    {
        transform.position = GameObject.Find("DaggerPrefab(Clone)").transform.position;
    }
}

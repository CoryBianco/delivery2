using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;

    [SerializeField]
    float destroyTime = .05f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        //  Debug.Log("witty message");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package")
        {
            if (!hasPackage)
            {
                Destroy(other.gameObject, destroyTime);
                hasPackage = true;
                Debug.Log("Picked up package package");
            }
            else
            {
                Debug.Log("Already have a package");
            }
        }
        else if (other.tag == "Customer")
        {
            if (hasPackage)
            {
                hasPackage = false;
                Debug.Log("Delivered Package");
            }
            else
            {
                Debug.Log("No Package to Deliver");
            }
        }
    }
}

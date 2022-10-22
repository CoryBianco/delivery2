using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour {
    [SerializeField]
    Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField]
    Color32 noPackageColor = new Color32(1, 0, 0, 1);
    bool hasPackage = false;
    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    [SerializeField]
    float destroyTime = .05f;

    private void OnCollisionEnter2D(Collision2D other) {
        //  Debug.Log("witty message");
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Package") {
            if (!hasPackage) {
                Destroy(other.gameObject, destroyTime);
                hasPackage = true;
                Debug.Log("Picked up package package");

                spriteRenderer.color = hasPackageColor;

            } else {
                Debug.Log("Already have a package");
            }
        } else if (other.tag == "Customer") {
            if (hasPackage) {
                hasPackage = false;
                Debug.Log("Delivered Package");

                spriteRenderer.color = noPackageColor;
            } else {
                Debug.Log("No Package to Deliver");
            }
        }
    }
}

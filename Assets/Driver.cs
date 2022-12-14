using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour {
    [SerializeField] float steerSpeed = 300.0f;
    [SerializeField] float moveSpeed = 20.0f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;


    void OnCollisionEnter2D() {
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Boost") {
            moveSpeed = boostSpeed;

        }
    }

    // Update is called once per frame
    void Update() {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float speedAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, speedAmount, 0);
        transform.Rotate(0, 0, -steerAmount);
    }
}

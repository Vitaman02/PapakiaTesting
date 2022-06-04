using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour {

    public CharacterController controller;
    float horizontalMove = 0f;

    Vector3 staticMovement = new Vector3(0.1f, 0f, 0f);

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        // Input.GetAxisRaw("Horizontal");
        // Debug.Log(Input.GetAxisRaw("Horizontal"));
        // horizontalMove = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate() {

        controller.Move(staticMovement);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour {

    public CharacterController controller;
    Vector3 staticMovement = new Vector3(0.1f, 0f, 0f);

    void FixedUpdate() {
        if (DuckMovement.On)
        controller.Move(staticMovement);

    }

    void OnBecameInvisible() {
        enabled = false;
    }
}

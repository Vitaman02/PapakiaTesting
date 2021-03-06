using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour {

    // Character controller
    public CharacterController controller;

    // Set direction for ducks
    // Direction = 1: Move to the right
    // Direction = -1: Move to the left
    public int direction = 1;

    // Movement and positions for ducks
    static readonly float travelSpeed = 0.2f;
    Vector3 startPositionLeft = new(-26f, 2.5f, 0f);
    Vector3 startPositionRight = new(27f, -4f, 0f);
    Vector3 staticMovementRight = new(travelSpeed, 0f, 0f);
    Vector3 staticMovementLeft = new(-travelSpeed, 0f, 0f);

    Renderer renderer;

    void Start() {
        renderer = GetComponent<Renderer>();
    }

    void FixedUpdate() {

        // Move element to the right of the camera
        // If the element if not visible and on the right of the camera,
        // then move it to the left of the camera
        Vector3 cameraPosition = Camera.main.transform.position;

        // Get object position according to camera
        bool leftOfCamera = cameraPosition.x > transform.position.x;
        bool rightOfCamera = cameraPosition.x < transform.position.x;

        // Check if object is visible
        bool isVisible = renderer.isVisible;

        // Check if object is on the left side or the right side
        // of the camera and outside of its view
        bool outsideCameraLeft = leftOfCamera && !isVisible;
        bool outsideCameraRight = rightOfCamera && !isVisible;

        if ((outsideCameraLeft || isVisible) && direction == 1) {
            // Get update position according to direction
            controller.Move(staticMovementRight);
        } else if ((outsideCameraRight || isVisible) && direction == -1) {
            controller.Move(staticMovementLeft);
        } else {
            // If the object is not longer visible,
            // then move it to the left of the camera again
            if (direction == 1) {
                transform.position = startPositionLeft;
            } else {
                transform.position = startPositionRight;
            }
        }
    }
}

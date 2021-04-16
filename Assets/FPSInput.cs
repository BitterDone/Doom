using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ?
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    private CharacterController cc;
    public float speed = 6.0f;
    public float gravity = -9.8f;

    void Start() {
        cc = GetComponent<CharacterController>();
    }

    // Update() called more often on systems with higher FPS
    // works but doesnt account for collisions with walls
    // private float makeFrameRateIndependant(float frameRateDependant) {
    //     return frameRateDependant * Time.deltaTime;
    // }
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        // works but doesnt account for collisions with walls
        // transform.Translate(
        //     makeFrameRateIndependant(deltaX),
        //     0, 
        //     makeFrameRateIndependant(deltaZ)
        // );
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        // otherwise diagonal motion goes farther (hypotenuse)
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        // transform World direction to player direction
        movement = transform.TransformDirection(movement);
        cc.Move(movement);
    }
}

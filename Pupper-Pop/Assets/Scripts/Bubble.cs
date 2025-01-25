using UnityEngine;
using UnityEngine.InputSystem;

public class Bubble : MonoBehaviour
{
    float grav = 0.0008f, drag = 0.2f;
    float vspeed = 0f, minVSpeed = -0.7f, jumpVSpeed = 0.9f;
    float hspeed = 0f, maxHSpeed = 0.6f, hspeedFactor = 0.8f; 
    float hMoveInput = 0f;

    void Update()
    {
        // Jumping gravity
        if (vspeed >= minVSpeed){
            vspeed -= grav;
            if (vspeed < minVSpeed)
                vspeed = minVSpeed;
        }
        // left/right drag
        if (Mathf.Abs(hspeed) > 0f){
            hspeed -= drag * System.Math.Sign(hspeed) * Time.deltaTime;
            if (Mathf.Abs(hspeed) < drag * Time.deltaTime)
                hspeed = 0f;
        }
        // left/right apply movement input
        if (Mathf.Abs(hMoveInput) > 0f){
            hspeed += hMoveInput * hspeedFactor * Time.deltaTime;
        }
        if (Mathf.Abs(hspeed) > maxHSpeed){
            hspeed = maxHSpeed * System.Math.Sign(hspeed);
        }
        // apply input to movement
        Vector3 pos = transform.position;
        pos.y += vspeed * Time.deltaTime;
        pos.x += hspeed * Time.deltaTime;
        transform.position = pos;
    }

    // Player Input Messages
    public void OnJump(){
        vspeed = jumpVSpeed;
    }

    public void OnMove(InputValue value){
        hMoveInput = value.Get<Vector2>().x;
    }

    public void OnPop(){
        Destroy(gameObject);
    }
}

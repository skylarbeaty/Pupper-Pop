using UnityEngine;
using UnityEngine.InputSystem;

public class Bubble : MonoBehaviour
{
    float grav = 0.008f, drag = 0.2f;
    float vspeed = 0f, minVSpeed = -0.7f, jumpVSpeed = 0.9f;
    float hspeed = 0f, maxHSpeed = 0.6f, hspeedFactor = 0.8f; 
    float hMoveInput = 0f;

    void FixedUpdate(){
        // Jumping gravity
        if (vspeed >= minVSpeed){
            vspeed -= grav;
            if (vspeed < minVSpeed)
                vspeed = minVSpeed;
        }
        // left/right drag
        if (Mathf.Abs(hspeed) > 0f){
            hspeed -= drag * System.Math.Sign(hspeed) * Time.fixedDeltaTime;
            if (Mathf.Abs(hspeed) < drag * Time.fixedDeltaTime)
                hspeed = 0f;
        }
        // left/right apply movement input
        if (Mathf.Abs(hMoveInput) > 0f){
            hspeed += hMoveInput * hspeedFactor * Time.fixedDeltaTime;
        }
        if (Mathf.Abs(hspeed) > maxHSpeed){
            hspeed = maxHSpeed * System.Math.Sign(hspeed);
        }
        // apply input to movement
        Vector3 pos = transform.position;
        pos.y += vspeed * Time.fixedDeltaTime;
        pos.x += hspeed * Time.fixedDeltaTime;
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
    
    // Collision
    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Pops")){
            OnPop();
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Pops")){
            OnPop();
        }
    }
}

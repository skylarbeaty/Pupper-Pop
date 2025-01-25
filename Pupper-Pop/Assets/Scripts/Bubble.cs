using UnityEngine;

public class Bubble : MonoBehaviour
{
    float grav = 0.004f, drag = 0.1f;
    float vspeed = 0f, minVSpeed = -1f, jumpVSpeed = 2f;
    float hspeed = 0f, maxHSpeed = 0.6f, hspeedFactor = 15f; 

    void Update()
    {
        // Jumping Input
        if (Input.GetButtonDown("Jump")){
            vspeed = jumpVSpeed;
        }
        if (vspeed >= minVSpeed){
            vspeed -= grav;
            if (vspeed < minVSpeed)
                vspeed = minVSpeed;
        }
        // left/right input
        if (Mathf.Abs(hspeed) > 0f){
            hspeed -= drag * System.Math.Sign(hspeed) * Time.deltaTime;
            if (Mathf.Abs(hspeed) < drag * Time.deltaTime)
                hspeed = 0f;
        }
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0f){
            hspeed += Input.GetAxisRaw("Horizontal") * hspeedFactor * Time.deltaTime;
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
}

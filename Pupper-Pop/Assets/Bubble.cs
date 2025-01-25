using UnityEngine;

public class Bubble : MonoBehaviour
{
    float grav = 0.03f, drag = 0.5f;
    float vspeed = 0f, minVSpeed = -2f, jumpVSpeed = 4f;
    float hspeed = 0f, maxHSpeed = 1f, hspeedFactor; 

    void Update()
    {
        if (Input.GetButtonDown("Jump")){
            print("jump");
            vspeed = jumpVSpeed;
        }
        if (vspeed >= minVSpeed){
            vspeed -= grav;
            if (vspeed < minVSpeed)
                vspeed = minVSpeed;
        }
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0f){
            hspeed += Input.GetAxis("Horizontal") * hspeedFactor * Time.deltaTime;
        }
        // if (Mathf.Abs(hspeed) > 0f){
            
        // }
        Vector3 pos = transform.position;
        pos.y += vspeed * Time.deltaTime;
        transform.position = pos;
    }
}

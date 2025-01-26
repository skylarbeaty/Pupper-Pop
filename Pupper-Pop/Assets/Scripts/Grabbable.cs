using UnityEngine;

public class Grabbable : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject target;
    public float smoothTime = 3F;
    private Vector3 velocity = Vector2.zero;
    public Collider2D collider;
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate(){
        if (target){
            // print("following");
            transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref velocity, smoothTime);
        }else {
            // collider.enable = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Bubble")){
            target = other.gameObject;
            // collider.enable = false;
        }
    }
}

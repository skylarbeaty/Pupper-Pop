using UnityEngine;

public class Grabbable : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject target;
    public bool isMainTreat = false;
    private Collider2D coll;
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }
    void FixedUpdate(){
        if (target){
            rb.MovePosition(Vector3.Lerp(transform.position, target.transform.position, 0.17f));
        }else{
            coll.enabled = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Bubble")){
            target = other.gameObject;
            coll.enabled = false;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Toxic")){
            if (isMainTreat)
                Object.FindAnyObjectByType<GameCanvas>().OnFail();
            Destroy(gameObject);
        }
    }
}

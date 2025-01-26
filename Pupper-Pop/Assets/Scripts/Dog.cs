using UnityEngine;

public class Dog : MonoBehaviour
{
    public GameObject bubble;
    public Transform bubbleSpawnTrans;
    public void OnJump(){
        if (Object.FindAnyObjectByType<GameCanvas>().gameOver)
            return;
        if (GameObject.FindGameObjectsWithTag("Bubble").Length == 0)
            Instantiate(bubble, bubbleSpawnTrans.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Grabbable")){
            Object.FindAnyObjectByType<GameCanvas>().OnSuccess();
        }
    }
}

using UnityEngine;

public class Dog : MonoBehaviour
{
    public GameObject bubble;
    public Transform bubbleSpawnTrans;
    public void OnJump(){
        if (GameObject.FindGameObjectsWithTag("Bubble").Length == 0)
            Instantiate(bubble, bubbleSpawnTrans.position, Quaternion.identity);
    }
}

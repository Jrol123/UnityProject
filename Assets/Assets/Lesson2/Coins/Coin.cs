using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player"){
            Destroy(transform.gameObject);
        }
    }
}

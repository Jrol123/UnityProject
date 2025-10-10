using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 camOffset;
    [SerializeField] private Transform Player;
    [SerializeField] private float speed = 0.5f;
    private float t = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Moving();
    }

    void Moving()
    {
        t += Time.deltaTime * speed;
        Vector3 new_pos = new Vector3(Player.position.x, 0, Player.position.z) + camOffset;
        transform.position = Vector3.Lerp(transform.position, new_pos, t * speed);
    }
}

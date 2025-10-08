using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // private Rigidbody rb;
    private Camera cam;
    private Vector3 camOffset;
    [SerializeField] private Transform Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // rb = Player.GetComponent<Rigidbody>();
        cam = GetComponent<Camera>();
        camOffset = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Moveing();
    }

    void Moveing()
    {
        // cam.transform.position.x = Player.position.x;
        Vector3 new_pos = new Vector3(Player.position.x, 0, Player.position.z) + camOffset;
        cam.transform.position = new_pos;

        // rb.MovePosition(rb.position + new Vector3(moveDir.x, 0, moveDir.y).normalized * moveSpeed * Time.fixedDeltaTime);
    }
}

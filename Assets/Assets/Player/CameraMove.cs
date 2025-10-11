using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 camOffset;
    [SerializeField] private Transform Player;
    [SerializeField] private float speed = 0.5f;

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
        Vector3 targetPosition = new Vector3(Player.position.x, 0, Player.position.z) + camOffset;
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );
    }
}

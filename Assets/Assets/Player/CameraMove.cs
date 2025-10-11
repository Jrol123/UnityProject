using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 camOffset;
    [SerializeField] private Transform Player;
    [SerializeField] private float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    // void LateUpdate()
    // {

    // }

    void Moving()
    {
        Vector3 targetPosition = new Vector3(Player.position.x, 0, Player.position.z) + camOffset;
        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPosition, ref velocity, smoothTime
        // speed * Time.deltaTime
        );
    }
}

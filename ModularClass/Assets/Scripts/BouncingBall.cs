using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    Rigidbody rb;
    bool bouncing;
    public float bounceForce = 3;
    float vertical = 0;
    float horizontal = 0;
    public static bool stop;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!rb || stop) return;

        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (!rb || stop) return;

        rb.AddForce(0, 0, 2 * vertical, ForceMode.Force);
        rb.AddForce(2 * horizontal, 0, 0, ForceMode.Force);

        if (Input.GetKey(KeyCode.Space))
        {
            if (bouncing) return;
            rb.AddForce(0, bounceForce, 0, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay (Collision collision)
    {
        bouncing = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        bouncing = true;
    }
}
using UnityEngine;

public class MovementCar : MonoBehaviour
{
    [SerializeField]
    private float relativeVelocity;
    [SerializeField]
    private FloatVariableSO carSpeed;
    private Rigidbody2D rb2d;
    
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb2d.velocity = Vector2.up * -carSpeed.Value;
        if(transform.position.y < -12f)
        {
            Destroy(gameObject);
        }
    }
}

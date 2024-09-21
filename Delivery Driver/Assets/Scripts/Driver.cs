using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // SerializeField önüne geldiği değişkeni
    // Unity üzerinden değiştirebilmeyi sağlar.

    float turnSpeed = -150f;
    float moveSpeed = 7f;
    float slowSpeed = 6f;
    float boostSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        float turnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // x ve y ekseninde 0°, z ekseninde 0.5°
        transform.Rotate(0f , 0f , turnAmount);
        // x ve z ekseninde 0°, y ekseninde 0.06°
        transform.Translate(0f, moveAmount, 0f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SpeedUp"){
            Debug.Log("Now it's a little fast and furious");
            moveSpeed = boostSpeed;
        }
    }
}
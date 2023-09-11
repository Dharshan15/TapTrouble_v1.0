using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static float speed = .6f; // Static speed variable shared among all instances of the class
    private static float lastSpeedUpdate; // Static variable to track the last speed update time

    void Update()
    {
        // Check if it's time to increase the speed
        if (Time.time - lastSpeedUpdate >= 10f)
        {
            speed += 0.15f; // Increase the static speed variable by 1
            lastSpeedUpdate = Time.time; // Update the last speed update time
        }

        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y <= -5.5f)
            Destroy(gameObject);


    }
}

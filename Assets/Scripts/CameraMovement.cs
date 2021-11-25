using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Target;
    public float Smoothing;
    public Vector2 MaxPosition;
    public Vector2 MinPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Called every fixed framerate frame
    void FixedUpdate()
    {
        // move towards target (player) if position isn't same as target position
        if (transform.position != Target.position)
		{
            Vector3 targetPosition = new Vector3(Target.position.x, Target.position.y, transform.position.z);

            // Clamps value between given min and max, returns value if within bounds
            targetPosition.x = Mathf.Clamp(targetPosition.x, MinPosition.x, MaxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, MinPosition.y, MaxPosition.y);

            // lerp = linear interpreation
            transform.position = Vector3.Lerp(transform.position, targetPosition, Smoothing);
		}
    }
}

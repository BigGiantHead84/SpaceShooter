using UnityEngine;
using System.Collections;

public class SingleJoystickPlayerController : MonoBehaviour
{
    // handle missing joystick must have a tleast 1 joystick
    public SingleJoystick singleJoystick;
    //public Transform myRotationObject; // The object we will be rotating when moving
    public float moveSpeed = 6.0f; // Character movement speed.
    //public int rotationSpeed = 8; // How quick the character rotate to target location.
    Vector3 input01;
    

    //Rigidbody rigidBody;

    //public Animator animator; // The animator for the toon. 

    // Use this for initialization
    void Start()
    {
        if (singleJoystick == null)
        {
            Debug.LogError("A single joystick is not attached.");
        }
       

    }

    void Update()
    {
        // get input from both joysticks
        input01 = singleJoystick.GetInputDirection();

        float xMovementInput01 = input01.x; // The horizontal movement from joystick 01
        float yMovementInput01 = input01.y; // The vertical movement from joystick 01	

        // if there is no input on joystick 01
        if (input01 == null)
        {
            Debug.Log("No input");
        }

        // if there is only input from joystick 01
        if (input01 != Vector3.zero)
        {
            //Move player the same distance in each direction. Player must move in a circular motion.

            float tempAngle = Mathf.Atan2(yMovementInput01, xMovementInput01);
            xMovementInput01 *= Mathf.Abs(Mathf.Cos(tempAngle));
            yMovementInput01 *= Mathf.Abs(Mathf.Sin(tempAngle));


            input01 = new Vector3(xMovementInput01, yMovementInput01, 0);
            
            input01 = transform.TransformDirection(input01);
            
            if (transform.position.x <= Utilities.xBoundMin)
            {
                if (input01.x <= 0) { 
                    input01 = new Vector3(0, input01.y,0);
                }
            }

            if (transform.position.x >= Utilities.xBoundMax)
            {
                Debug.Log("Out of bounds");
                if (input01.x >= 0)
                {
                    Debug.Log("We're still moving to right");
                    input01 = new Vector3(0, input01.y, 0);
                }
            }

            if (transform.position.y <= Utilities.yBoundMin )
            {
                if (input01.y <= 0)
                {
                    input01 = new Vector3(input01.x, 0, 0);
                }
            }
            if (transform.position.y >= Utilities.yBoundMax)
            {
                if (input01.y >= 0)
                {
                    input01 = new Vector3(input01.x, 0, 0);
                }
            }

            input01 *= moveSpeed;
            transform.Translate(input01 * Time.deltaTime);
            
        }
    }

    /*void FixedUpdate()
    {


             Make rotation object(The child object that contains animation) rotate to direction we are moving in.
            Vector3 temp = transform.position;
            temp.x += xMovementInput01;
            temp.z += zMovementInput01;
            Vector3 lookingVector = temp - transform.position;
            if (lookingVector != Vector3.zero)
            {
                myRotationObject.localRotation = Quaternion.Slerp(myRotationObject.localRotation, Quaternion.LookRotation(lookingVector), rotationSpeed * Time.deltaTime);
            }
            if (animator != null)
            {
                animator.SetBool("isRunning", true);
            }

            rigidBody.transform.Translate(input01 * Time.fixedDeltaTime);

        }
    */
}
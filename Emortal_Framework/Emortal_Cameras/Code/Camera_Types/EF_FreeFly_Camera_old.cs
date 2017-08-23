using UnityEngine;

/* A free-fly camera using standard inputs
 * mouse-look rotation
 * ESC key to toggle cursor visibility
*/
namespace Emortal.Cameras
{
    public class EF_FreeFly_Camera : EF_Base_Camera
    {
        #region Variables
        [Space(10f)]
        [Header("Free Fly Properties")]
        public float startSpeed = 10f;
        public Vector3 velocity = Vector3.zero;
        public float gainSpeed = 1f;
        public float smoothTime = 0.5f;

        [Header("Input Properties")]
        public inputType inputControl = inputType.WASD;
        public enum inputType
        {
            Xbox,
            WASD
        };

        [Space(10f)]
        public KeyCode forwardInput = KeyCode.W;
        public KeyCode backwardInput = KeyCode.S;
        public KeyCode rightInput = KeyCode.D;
        public KeyCode leftInput = KeyCode.A;

        Vector3 wantedPosition;
        #endregion

        #region Main Methods
        public override void OnEnable()
        {
            base.OnEnable();
            wantedPosition = transform.position;
        }
        #endregion

        #region Custom methods
        //Updates the Translation of the Camera Type
        protected override void UpdateTranslation()
        {
            HandleCursor();

            if (canMove)
            {
                bool lastMoving = isMoving;
                Vector3 deltaPosition = Vector3.zero;
                if (isMoving)
                {
                    currentSpeed += gainSpeed * Time.deltaTime;
                }
                isMoving = false;

                CheckMovement(inputControl, ref deltaPosition);

                if (isMoving)
                {
                    if (isMoving != lastMoving)
                    {
                        currentSpeed = startSpeed;
                    }
                }
                else
                {
                    currentSpeed = 0f;
                }

                wantedPosition += deltaPosition * currentSpeed * Time.deltaTime;
                transform.position = Vector3.SmoothDamp(transform.position, wantedPosition, ref velocity, smoothTime);
            }
        }

        //Updates the Rotation of the Camera Type
        protected override void UpdateRotation()
        {
            if (canRotate)
            {
                Vector3 eulerAngles = transform.eulerAngles;
                CheckRotation(inputControl, ref eulerAngles);

                transform.eulerAngles = eulerAngles;
            }
        }

        //Sets rotation angles based on input type
        protected void CheckRotation(inputType inputControl, ref Vector3 eulerAngles)
        {
            switch (inputControl)
            {
                case inputType.WASD:
                    eulerAngles.x += -Input.GetAxis("Mouse Y") * 359f * cursorSensitivity; 
                    eulerAngles.y += Input.GetAxis("Mouse X") * 359f * cursorSensitivity;
                    break;

                case inputType.Xbox:
                    eulerAngles.x += Input.GetAxis("XRightVertical") * 359f * cursorSensitivity;
                    eulerAngles.y += Input.GetAxis("XRightHorizontal") * 359f * cursorSensitivity;
                    break;
            }
        }

        //Sets direction based on input type
        protected void CheckMovement(inputType inputControl, ref Vector3 deltaPosition)
        {
            switch(inputControl)
            {
                case inputType.WASD:
                    if (Input.GetKey(forwardInput))
                    {
                        isMoving = true;
                        deltaPosition += transform.forward;
                    }
                    if (Input.GetKey(backwardInput))
                    {
                        isMoving = true;
                        deltaPosition += -transform.forward;
                    }
                    if (Input.GetKey(rightInput))
                    {
                        isMoving = true;
                        deltaPosition += transform.right;
                    }
                    if (Input.GetKey(leftInput))
                    {
                        isMoving = true;
                        deltaPosition += -transform.right;
                    }
                    break;

                case inputType.Xbox:

                    float moveHorizontal = Input.GetAxis("Horizontal");
                    float moveVertical = Input.GetAxis("Vertical");
                    if (Mathf.Abs(moveHorizontal) > 0 || Mathf.Abs(moveVertical) > 0)
                    {
                        isMoving = true;
                        deltaPosition += new Vector3(moveHorizontal,0, moveVertical);
                    }
                    break;
            }
        }
        #endregion
    }
}

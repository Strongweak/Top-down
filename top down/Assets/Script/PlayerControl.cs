using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody rb;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera pcam;
    public GunControl theGun;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pcam = FindObjectOfType<Camera>();

    }
    void Update()
    {
        //get position of mouse
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        //create a invinsible ray from camera to mouse position
        Ray cameraRay = pcam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        //draw a line(blue) to debug camera look position
        if(groundPlane.Raycast(cameraRay,out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook,Color.blue);

            transform.LookAt(new Vector3(pointToLook.x,transform.position.y,pointToLook.z));
        }

        //command shoot bullet when click left mouse(0)
        if (Input.GetMouseButtonDown(0))
        {
            theGun.isFiring = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            theGun.isFiring = false;
        }
 
    }

     void FixedUpdate()
    {
        rb.velocity = moveVelocity;
    }
}

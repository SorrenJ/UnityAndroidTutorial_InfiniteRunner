using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //for managing scenes like restarting a scene

public class PlayerController : MonoBehaviour

{

Rigidbody rb;
public float jumpForce;
bool canJump;

private void Awake(){
    rb = GetComponent<Rigidbody>();//gathers all values from rigidBody

}

    // Start is called before the first frame update
        void Start()
    {
        //start
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canJump) //Leftmouse button or tap
        {
            //jump
            canJump=false; //needs this otherwise it woont become false
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }
    }

private void OnCollisionEnter(Collision collision) //for only one jump
{
    if(collision.gameObject.tag == "Ground")
    {
        canJump = true;
    }
}

private void OnOnCollisionExit(Collision collision)
{
    if (collision.gameObject.tag == "Ground")
    {
        canJump = false;

    }
}

//detect if collide with obstcle
private void OnTriggerEnter(Collider other)//other all properties of collider
{
if (other.gameObject.tag == "Obstacle")
{

    SceneManager.LoadScene("Game"); //restart game
}
}
}

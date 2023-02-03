using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TMP_Text scoreText, pickupsText;
    // public TMP_Text timeText;
    public Rigidbody rb;
    private float movX, movY;
    private float rotX, rotY;
    private bool isGrounded; 
    private float speed = 10;

    private float orientation = 1; 
    // private float currentTime = 0f;
    // private int lastTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> pickupsChildren = new(GameObject.FindGameObjectsWithTag("Bronze"));
        Globals.PickupsLeft = pickupsChildren.Where(p => p.activeSelf).Count();;

        Globals.UpdateScoreText(scoreText, pickupsText);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>() * orientation;
        movX = movementVector.x;
        movY = movementVector.y;
    }

    void OnJump(InputValue jumpValue)
    {
        Debug.Log(isGrounded);
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * 8, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnLook(InputValue lookValue)
    {
        rotX = lookValue.Get<Vector2>().x;
    }

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag) 
        {
            case "Ground":
                isGrounded = true;
                break;

            case "DukeProjectile":
                Globals.LevelScore -= 100;
                Globals.UpdateScoreText(scoreText, pickupsText);
                other.gameObject.SetActive(false);
                break;
            
            default:
                break;
        }
    }
    
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Rails") 
            rb.AddForce(Vector3.forward * 200, ForceMode.Force);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        switch(other.gameObject.tag)
        {
            case "Bronze": 
                Globals.LevelScore += 100;
                --Globals.PickupsLeft;
                Globals.UpdateScoreText(scoreText, pickupsText);
                other.gameObject.SetActive(false);
                break;
            
            case "Checkpoint":
                Globals.LastCheckPoint = other.transform.position;
                break;

            // Reset velocity and teleport to last checkpoint
            case "DeathPlane":
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                transform.eulerAngles = Vector3.zero;
                transform.position = Globals.LastCheckPoint;
                break;

            case "Exit":
                Globals.LoadNextScreen();
                break;

            default:
                break;
        }
    }

    void Update()
    {
        // Update timer
        // currentTime += 1 * Time.deltaTime;
        // Globals.UpdateTimer(currentTime, timeText);
        // if ((int) currentTime 2!= lastTime) lastTime = (int) currentTime;
    }

    void FixedUpdate()
    {
        // Debug.Log(rb.velocity.y);
        rb.AddForce(new Vector3(movX, 0, movY) * speed);

        var currentRot = transform.rotation;
        transform.rotation = new Quaternion(
            currentRot.x + rotX,
            currentRot.y, 
            currentRot.z,
            currentRot.w
        );
    }
}

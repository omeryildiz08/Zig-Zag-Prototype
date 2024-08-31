using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public  float speed = 5f;
    CurrentDirection cr;
    public bool isPlayerDead;
    private GameManager gameManager;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cr = CurrentDirection.left;
        isPlayerDead = false;
        gameManager = FindObjectOfType<GameManager>();
        
        
    }
    private void Update()
    {

        //for mobile but we're making this for pc  if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) ;
        //  {
        //      ChangeDirection();
        //      PlayerStop();
        //  }
        if (isPlayerDead == false)
        {
            RaycastDetector();
            if (Input.GetKeyDown("space"))
            {
                ChangeDirection();
                PlayerStop();
            }
            else
            {
                return; 
            }
        }
        
        
    }


    private void RaycastDetector()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position,Vector3.down, out hit))
        {
            MovePlayer();
        }
        else
        {
            PlayerStop();
            isPlayerDead = true;
            gameManager.LevelEnd();
        }
    }
        

    private enum CurrentDirection
    {
        right,left,vertical
    }
    private void ChangeDirection()
    {
        MovePlayer();
        if (cr == CurrentDirection.right)
        {
            cr = CurrentDirection.left;
        }
        else if (cr == CurrentDirection.vertical)
        {
            cr = CurrentDirection.vertical;
        }
        else if (cr == CurrentDirection.left)
        {
            cr = CurrentDirection.right;
        }
    }
    private void MovePlayer()
    {
        if (cr == CurrentDirection.vertical)
        {
            rb.AddForce((Vector3.forward).normalized * speed * Time.deltaTime,ForceMode.VelocityChange);

        }
        else if (cr == CurrentDirection.right)
        {
            rb.AddForce((Vector3.left).normalized * speed * Time.deltaTime, ForceMode.VelocityChange);

        }
        else if(cr == CurrentDirection.left)
        {
            rb.AddForce((Vector3.right).normalized * speed * Time.deltaTime,ForceMode.VelocityChange);

        }
    }

    private void PlayerStop()
    {
        rb.velocity = Vector3.zero;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndTrigger"))
        {
            gameManager.WinLevel();
            PlayerStop();
            this.gameObject.SetActive(false);
        }
    }
}

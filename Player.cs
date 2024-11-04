using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // its access level: public or private
    // its type: int (5, 8, 36, etc.), float (2.5f, 3.7f, etc.)
    // its name: speed, playerSpeed --- Speed, PlayerSpeed
    // optional: give it an initial value 
    private float speed;
    private int lives = 3;
    private int score = 0;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 screenBounds;

    public GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()  
    {
        Movement();
        Shooting();
        BoundaryCheck();
    }
    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * 5);

        // if (condition) { //do this }
        // else if (other condition) { //do that }
        // else { //do this final }
        if (transform.position.x >= 11f || transform.position.x < -11f)  
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }

        if (transform.position.y >= 8f || transform.position.y < -8f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }
    }  
    void BoundaryCheck()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x, screenBounds.x * -1);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y, screenBounds.y * -1);
        transform.position = viewPos;
    }
    void Shooting()
    {
        // if I press Space
        // I will create a bullet
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Create a bullet
            Instantiate(Bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}

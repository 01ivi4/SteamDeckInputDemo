using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput; //player input system I'm reading from
    InputAction moveInput, fireInput, exitInput;
    public float moveSpeed;
    void Awake()
    {
        playerInput = new PlayerInput(); //starts reading the input system
    }

    void OnEnable()
    {
        moveInput = playerInput.Player.Move;
        moveInput.Enable();

        fireInput = playerInput.Player.Fire;
        fireInput.Enable();
        fireInput.performed += Fire;

        exitInput = playerInput.Player.Exit;
        exitInput.Enable();
        exitInput.performed += Quit;
    }

    void OnDisable()
    {
        moveInput.Disable();
        fireInput.Disable();
        exitInput.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vectorInput = moveInput.ReadValue<Vector2> ();

        //Debug.Log("Input is " + vectorInput.x + " x and " + vectorInput.y);
        transform.Translate(new Vector3(vectorInput.x, 0, vectorInput.y) * Time.deltaTime * moveSpeed);
    }

    void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Pew Pew *Gun sound*");
    }

    void Quit(InputAction.CallbackContext context)
    {
        Application.Quit();
    }
}

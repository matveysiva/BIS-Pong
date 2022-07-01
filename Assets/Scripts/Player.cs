using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualPantoFramework;
using System.Threading.Tasks;

public enum ePlayer
{
    Left,
    Right
}

public class Player : MonoBehaviour
{

    public float speed = 15f;
    public ePlayer player;
    public Rigidbody playerRb;

    async void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        await ActivatePlayer();
    }
    
    public async Task ActivatePlayer()
    {
        UpperHandle upperHandle = GameObject.Find("Panto").GetComponent<UpperHandle>();
        await upperHandle.SwitchTo(gameObject);
        upperHandle.FreeRotation();
    }

    void FixedUpdate()
    {
        PantoMovement();  
    }

    // Update is called once per frame
    void Update()
    {
        // float inputSpeed = 0f;
        // if(player == ePlayer.Left)
        // {
        //     inputSpeed = Input.GetAxis("PlayerLeft");
        // }
        // if (player == ePlayer.Right)
        // {
        //     inputSpeed = Input.GetAxis("PlayerRight");
        // }

        // transform.position += new Vector3(0f, 0f, inputSpeed * speed * Time.deltaTime);  
    }

    void PantoMovement()
    {
        float rotation = GameObject.Find("Panto").GetComponent<UpperHandle>().GetRotation();
        transform.eulerAngles = new Vector3(0, rotation, 0);
        playerRb.velocity = speed * transform.forward;
    }
}

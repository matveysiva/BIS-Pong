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

    private Rigidbody playerRb;
    public ePlayer player;
    PantoHandle upperHandle;
    public float speed = 15f;
    // bool free = true;

    async void Start()
    {
        upperHandle = GameObject.Find("Panto").GetComponent<UpperHandle>();
        // playerRb = GetComponent<Rigidbody>();
        await upperHandle.MoveToPosition(transform.position);
        // await ActivatePlayer();
    }
    
    // public async Task ActivatePlayer()
    // {
    //     await upperHandle.MoveToPosition(transform.position);
    // }

    void FixedUpdate()
    {
        Debug.Log("Player.FixedUpdate");
        transform.position = (upperHandle.HandlePosition(transform.position));
        // transform.eulerAngles = new Vector3(0, upperHandle.GetRotation(), 0);
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey(KeyCode.F))
        // {
        //     if (free)
        //     {
        //         upperHandle.Freeze();
        //     }
        //     else
        //     {
        //         upperHandle.Free();
        //     }
        //     free =! free;
        // }

        float inputSpeed = 0f;
        // if(player == ePlayer.Left)
        // {
        //     inputSpeed = Input.GetAxis("PlayerLeft");
        // }
        if (player == ePlayer.Right)
        {
            inputSpeed = Input.GetAxis("PlayerRight");
        }

        transform.position += new Vector3(0f, 0f, inputSpeed * speed * Time.deltaTime);  
    }
}

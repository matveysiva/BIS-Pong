using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualPantoFramework;
using System.Threading.Tasks;

public class Ball : MonoBehaviour
{

    PantoHandle lowerHandle;
    private Rigidbody ballRb;
    public Vector3 initialImpulse;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        lowerHandle = GameObject.Find("Panto").GetComponent<LowerHandle>();
    }

    public async Task ActivateBall()
    {
        await lowerHandle.SwitchTo(gameObject);
        ballRb.AddForce(initialImpulse, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualPantoFramework;
using System.Threading.Tasks;

public class Ball : MonoBehaviour
{

    public Vector3 initialImpulse;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(initialImpulse, ForceMode.Impulse);
    }

    async Task ActivateBall()
    {
        await GameObject.Find("Panto").GetComponent<LowerHandle>().SwitchTo(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

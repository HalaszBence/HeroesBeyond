using Unity.Netcode;
using UnityEngine;

public class Hero : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOwner && Input.GetKey("right")) {
            transform.position = new Vector3(transform.position.x+0.5f*Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    [SerializeField] Transform playerCar;
    [SerializeField] float cameraOffset;
    // Start is called before the first frame update
    void Start()
    {
        if (playerCar == null)
        {
            playerCar = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerCar.position.x + cameraOffset, transform.position.y, transform.position.z);
    }
}

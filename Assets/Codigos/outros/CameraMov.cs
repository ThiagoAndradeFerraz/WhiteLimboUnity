using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    private Vector2 velocidade;
    public float suavidadeX, suavidadeY;
    public GameObject player;

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocidade.x, suavidadeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocidade.y, suavidadeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

    }
}

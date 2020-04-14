using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle_Player : MonoBehaviour
{
    // -- MOVIMENTAÇÃO -- 
    private float velocidade = 50;
    public bool correndo = false;
    public bool pdAndar = true;
    // ------------------

    // -- INVENTARIO ----
    public GameObject controleInvt;
    protected bool exibeUIinvt = false;
    // ------------------

    public void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Andar();
    }

    void Update()
    {
        UsarInventario();
    }

    void Andar()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidade = 100;
            correndo = true;
        }
        else
        {
            if(correndo == true)
            {
                velocidade = 50;
                correndo = false;
            }
        }


        float x = Input.GetAxis("Horizontal") * Time.deltaTime * velocidade;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * velocidade;

        transform.Translate(x, 0, z);
    }


    void UsarInventario()
    {
        /*
        if (Input.GetKeyDown(KeyCode.R))
        {
            controleInvt.GetComponent<ControleInvt>().UsarItem(1);
        }
        else if (Input.GetKeyDown(KeyCode.T)){
            controleInvt.GetComponent<ControleInvt>().UsarItem(2);
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            controleInvt.GetComponent<ControleInvt>().UsarItem(3);
        }*/

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            controleInvt.GetComponent<ControleInvt>().ExibirPainel(!exibeUIinvt);
            exibeUIinvt = !exibeUIinvt;
        }
    }
}

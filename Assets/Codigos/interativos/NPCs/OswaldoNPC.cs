using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OswaldoNPC : NPCGenerico
{
    
    void Start()
    {
        CarregarTexto(txtAsset);
        //IterarTexto();
    }

    
    void Update()
    {
        DetectarProximidade();   
    }

    protected override void Interacao()
    {
        IterarTexto();
    }


}

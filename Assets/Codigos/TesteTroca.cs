using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteTroca : MonoBehaviour
{

    private SpriteRenderer spriteRend;
    private Sprite neutroSprite;


    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();

        spriteRend.sprite = Resources.Load<Sprite>("NEUTRO-1");

        //FUNCIONANDO, NÃO MEXE!
        //neutroSprite = Resources.Load<Sprite>("NEUTRO-1");
        //spriteRend.sprite = neutroSprite;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

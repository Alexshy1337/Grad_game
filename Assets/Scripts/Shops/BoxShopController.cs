using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxShopController : MonoBehaviour
{
    public int price = 0;
    private bool inRange = false;
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //check wwhich trigger was touched

        //if boxCollider
        //inRange = true;
        //deactivate box collider
        //activate edge collider
        //if edge collider
        //inRange = false;
        //deactivate box collider
        //activate edge collider


    }




    public virtual void Buy()
    {
        if(inRange)
        {
            //soldier -> get New weapon
            //money -= price

        }
    }

}

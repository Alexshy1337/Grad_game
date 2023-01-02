using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxShopController : MonoBehaviour
{
    public int price = 0;
    private bool inactive = true;
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        StartCoroutine(ShopCoroutine());
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        StopAllCoroutines();
    }

    public void StopAllCoroutines()
    {
        inactive = true;
    }

    //void Update()
    //Input.GetButtonDown("????")


    public virtual IEnumerator ShopCoroutine()
    {
        inactive = false;
        while (true)
        {
            if (inactive)
                break;
            Buy();
            yield return new WaitForSeconds(1f);
        }
        yield return 0;
    }

    public virtual void Buy()
    {
        //Input.GetButtonDown("????");
        //
    }

}

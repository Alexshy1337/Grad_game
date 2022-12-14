using UnityEngine;

public class BloodStainDissapear : MonoBehaviour
{
    private SpriteRenderer spr;

    void Start()
    {
        spr = (SpriteRenderer) gameObject.GetComponent("SpriteRenderer");
    }

    void Update()
    {
        spr.color = new Color(1f, 1f, 1f, Mathf.Lerp(spr.color.a, 0f, Time.deltaTime * 0.03f));
        if (spr.color.a <= 0.09f)
            Destroy(gameObject);
    }
}

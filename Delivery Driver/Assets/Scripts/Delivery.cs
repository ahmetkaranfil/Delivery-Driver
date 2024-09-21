using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 0, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);
        
    // Let's determine the time of destroy
    float destroyDelay = 0.5f;
    // Let's check we received the package or not
    bool hasPackage = false;

    // define the package color
    Color32 packageColor;
    // define the custumer color
    Color32 custumerColor;
    
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // if (the thing we trigger is the package)
        // then print the console "The package picked up
        if(collision.tag == "Package" && hasPackage == false)
        {
            Debug.Log("The package picked up!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            packageColor = collision.GetComponent<SpriteRenderer>().color;
            Destroy(collision.gameObject, destroyDelay);
        }
        
        if(collision.tag == "Customer" && hasPackage == true)
        {
            custumerColor = collision.GetComponent<SpriteRenderer>().color;
            if(packageColor.Equals(custumerColor))
            {
                Debug.Log("The package delivered!");
                hasPackage = false;
                spriteRenderer.color = noPackageColor;
                Destroy(collision.gameObject, destroyDelay);
            }
            else
            {
                Debug.Log("Wrong custumer!");
            }
        }
    }
}
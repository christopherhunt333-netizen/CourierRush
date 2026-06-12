using UnityEngine;

public class Target : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite packageSprite;
    [SerializeField] private Sprite deliverySprite;
    private string packageTag = "Package";
    private string deliveryTag = "Delivery";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        ChangeTag(packageTag);
        ChangeSprite(packageSprite);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (gameObject.CompareTag("Package"))
        {
            ChangeTag(deliveryTag);
            ChangeSprite(deliverySprite);

        }
        else if (gameObject.CompareTag("Delivery"))
        {
            ChangeTag(packageTag);
            ChangeSprite(packageSprite);
        }

    }

    void ChangeTag(string targetString)
    {
        if (gameObject.tag != null && targetString != null)
        {
            gameObject.tag = targetString;
        }
        
    }
    void ChangeSprite(Sprite targetSprite)
    {
        if (spriteRenderer != null && targetSprite != null)
        {
            spriteRenderer.sprite = targetSprite;
        }
    }
}

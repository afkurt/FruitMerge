using UnityEngine;

public class Fruit : MonoBehaviour
{
    public FruitData data;
    private SpriteRenderer _sr;

    public bool isMerged;
    public Rigidbody2D rb {  get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.sprite = data.sprite;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Fruit")) return;

        Fruit other = collision.gameObject.GetComponent<Fruit>();

        if(other.data == data)
        {
            isMerged = true;
            
            MergeManager.OnMergeRequest?.Invoke(this, other);
        }
    }

}

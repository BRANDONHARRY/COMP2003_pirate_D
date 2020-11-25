using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMineScript : MonoBehaviour
{
    public SpriteRenderer rend;
    public int damage = 5;
    public int delay = 5;
    public Sprite hideSprite;
    public Sprite seeSprite;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        //rend = GetComponent<SpriteRenderer>();
        rend.sprite = hideSprite;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        StartCoroutine(WaitTime(other));
        
    }
    
    private IEnumerator WaitTime(Collider2D other)
    {
        rend.sprite = seeSprite;

        yield return new WaitForSecondsRealtime(delay);

        distance = Vector3.Distance(transform.position, other.transform.position);

        if (distance < 1)
        {
            other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver); 
        }
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMineScript : MonoBehaviour
{
    //public SpriteRenderer rend;
    public int damage = 5;
    public int delay = 5;

    // Start is called before the first frame update
    void Start()
    {
        //rend = GetComponent<SpriteRenderer>();
        //rend.enable = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //rend.enable = true;
        StartCoroutine(WaitTime());
        other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        Die();
    }
    
    private IEnumerator WaitTime()
    {
        yield return new WaitForSecondsRealtime(delay);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pearl : MonoBehaviour
{
    public int value;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Counter.instance.IncreasePearls(value);
        }

        if(collision.tag == "Player")
        {
            var healthComponent = collision.GetComponent<healthManager>();
            if(healthComponent != null)
            {
                healthComponent.TakeDamage(1);
                Debug.Log("Collision");
            }
        }
    }
}

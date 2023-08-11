using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class takeItems : MonoBehaviour
{
    [SerializeField] float healthRecup;
    [SerializeField] Text gemTexte;
    [SerializeField] GameObject soundGem;
    [SerializeField] GameObject soundCherry;

    Animator animator;
    CircleCollider2D CircleCollider2D;

    void Start()
    {
        gemTexte.text = playerInventory.InstanceInventory.Gem.ToString();
    }
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "cherry")
        {
            if (soundCherry)
            {
                Instantiate(soundCherry, transform.position, Quaternion.identity);
            }

            healthRecup = gameManager.InstanceGame.Heal;
            animator = collision.GetComponent<Animator>();
            CircleCollider2D = collision.GetComponent<CircleCollider2D>();

            CircleCollider2D.enabled = false;
            playerInventory.InstanceInventory.Heal(healthRecup);
            animator.SetBool("isTake", true);
            StartCoroutine(waitFeedBack(collision.gameObject));
        }
        else if(collision.gameObject.tag == "gem")
        {
            if(soundGem)
            {
                Instantiate(soundGem, transform.position, Quaternion.identity);
            }
            
            animator = collision.GetComponent<Animator>();
            CircleCollider2D = collision.GetComponent<CircleCollider2D>();

            CircleCollider2D.enabled = false;
            playerInventory.InstanceInventory.AddGem();
            animator.SetBool("isTake", true);
            gemTexte.text = playerInventory.InstanceInventory.Gem.ToString();
            StartCoroutine(waitFeedBack(collision.gameObject));
        }
    }

    IEnumerator waitFeedBack(GameObject item)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(item);
    }
}

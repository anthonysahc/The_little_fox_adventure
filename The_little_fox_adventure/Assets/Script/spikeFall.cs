using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeFall : MonoBehaviour
{
    [Range(0, 100f)][SerializeField] float randomApparition = 90f;
    [SerializeField] Vector3 offset;
    

    public GameObject spike;

    private bool isFall = false;

    void Start()
    {
        offset.y = 7;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isFall)
            {
                if (Random.Range(0f, 100f) < randomApparition && isFall == false)
                {
                    Instantiate(spike, gameManager.InstanceGame.Player.transform.position + offset, Quaternion.identity, transform);

                }
                StartCoroutine(waihtFall());
            }
        }
    }

    IEnumerator waihtFall()
    {
        isFall = true;
        yield return new WaitForSeconds(1f);
        isFall = false;
    }
}

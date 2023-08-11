using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogJump : MonoBehaviour
{
    [SerializeField] int nbBond = 1;
    [SerializeField] int nbCroak = 1;
    [SerializeField] float jumpForceY = 300;
    [SerializeField] float jumpForceX = 120;
    [SerializeField] LayerMask groundLayer; // Référence au layer avec lequel nous allons checker la colision
    [SerializeField] LayerMask propsLayer;
    [SerializeField] Transform groundCheck; // Référence au GroundCheckLocation

    Rigidbody2D frogRB;
    Animator frogAnim;

    bool ground = true; // Valeur qui traque si la grenouille est au sol ou non
    float groundCheckRadius = .2f; // Raduis du cercle pour tester si la grenouille est en contact avec le sol(Peut etre change en fonction des assets)
    int contNbBond = 0; // Valeur pour conter le nombre de saut 
    bool canJump; // Valeur pour savoir si la frog peut sauter
    bool facingLeft = true; // Valeur pour le flip


    void Start()
    {
        frogRB = GetComponent<Rigidbody2D>();
        frogAnim = GetComponent<Animator>();

        jumpForceX = -jumpForceX; // Pour que la frog saute du coté à gauch en premier
        canJump = true;
    }

    void Update()
    {
        ground = (Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer) || Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, propsLayer)); // Teste si la frog est au sol

        if (canJump && ground)
        {
            canJump = false;

            StartCoroutine(waitCroak()); // On atttend l'annimation de la frog
        }

        frogAnim.SetBool("isJump", !ground);
        frogAnim.SetFloat("verticalVelocity", frogRB.velocity.y);

    }

    IEnumerator waitCroak()
    {
        if (contNbBond >= nbBond)
        {
            Flip();
        }
        yield return new WaitForSeconds(0.85f * nbCroak);
        frogRB.AddForce(new Vector2(jumpForceX, jumpForceY), ForceMode2D.Impulse); // Saut
        ++contNbBond;
        yield return new WaitForSeconds(0.1f);
        canJump = true;
    }

    void Flip()
    {
        if(facingLeft)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        facingLeft = !facingLeft;
        contNbBond = 0;
        jumpForceX = -jumpForceX;
    }
}

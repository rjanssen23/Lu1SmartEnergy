using UnityEngine;

public class SchatkistAnimatieController : MonoBehaviour
{
    public Animator animator;
    public float animatieSnelheid = 0.5f; // Pas deze waarde aan om de animatie langzamer of sneller te maken

    void Start()
    {
        // Zorg ervoor dat de animator component is ingesteld
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // Stel de snelheid van de animatie in
        animator.speed = animatieSnelheid;

        // Start de animatie
        animator.Play("SchatkistAnimatie");
    }
}

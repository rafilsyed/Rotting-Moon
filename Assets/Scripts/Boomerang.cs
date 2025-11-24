using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public float speed = 15f;           // Vitesse du vol
    public float rotationSpeed = 800f;  // Vitesse de rotation sur lui-même
    public float maxDistance = 20f;     // Distance max avant de revenir

    [HideInInspector] 
    public Transform playerTarget;      // Le joueur (rempli automatiquement)

    private Vector3 startPosition;
    private bool isReturning = false;   // Est-ce qu'on revient ?
    public Transform visualModel;       // Le modèle 3D qui tourne (optionnel)

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // 1. Faire tourner le visuel (si assigné, sinon l'objet entier)
        if (visualModel != null)
        {
            visualModel.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        else
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }

        // 2. Gestion du mouvement
        if (!isReturning)
        {
            // PHASE 1 : On s'éloigne tout droit
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            // Si on est trop loin, on passe en mode retour
            if (Vector3.Distance(startPosition, transform.position) >= maxDistance)
            {
                isReturning = true;
            }
        }
        else
        {
            // PHASE 2 : On revient vers le joueur
            // On se déplace point par point vers la position actuelle du joueur
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, speed * Time.deltaTime);

            // Si on touche le joueur (distance très faible), on détruit le boomerang
            if (Vector3.Distance(transform.position, playerTarget.position) < 1.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
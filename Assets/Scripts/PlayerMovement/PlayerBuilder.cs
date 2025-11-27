using UnityEngine;

public class PlayerBuilder : MonoBehaviour
{
    [Header("Réglages")]
    public GameObject raftPrefab; // Glisse le Prefab 
    public float distanceConstruction = 5f; // Distance max pour atteindre le point
    public KeyCode toucheConstruction = KeyCode.E; // La touche pour construire

    void Update()
    {
        // Si le joueur appuie sur "E"
        if (Input.GetKeyDown(toucheConstruction))
        {
            RegarderEtConstruire();
        }
    }

    void RegarderEtConstruire()
    {
        // On crée un rayon invisible qui part du centre de la caméra (là où tu regardes)
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // On lance le rayon
        if (Physics.Raycast(ray, out hit, distanceConstruction))
        {
            // Est-ce que l'objet touché a "SnapPoint" 
            if (hit.collider.name.Contains("SnapPoint"))
            {
                
                
                // 1. Créer le nouveau radeau à la position du point visé
                Instantiate(raftPrefab, hit.collider.transform.position, hit.collider.transform.rotation);

                // 2. Supprimer le point d'accroche 
                Destroy(hit.collider.gameObject);
                
                Debug.Log("Radeau construit !");
            }
        }
    }
}
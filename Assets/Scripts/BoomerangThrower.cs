using UnityEngine;

public class BoomerangThrower : MonoBehaviour
{
    public GameObject boomerangPrefab; // Le préfabriqué du boomerang
    public Transform throwPoint;       // L'endroit d'où part le tir (ex: la main)

    void Update()
    {
        // Clic Gauche de la souris
        if (Input.GetMouseButtonDown(0)) 
        {
            Throw();
        }
    }

    void Throw()
    {
        if (boomerangPrefab != null && throwPoint != null)
        {
            // 1. Créer le boomerang
            GameObject clone = Instantiate(boomerangPrefab, throwPoint.position, throwPoint.rotation);
            
            // 2. Récupérer son script et lui dire "Je suis ton maître, reviens vers moi !"
            Boomerang script = clone.GetComponent<Boomerang>();
            script.playerTarget = this.transform; 
        }
    }
}
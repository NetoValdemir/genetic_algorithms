using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA : MonoBehaviour
{
    // Características do indivíduo
    public float r;                             // Gene de cor R
    public float g;                             // Gene de cor G
    public float b;                             // Gene de cor B
    public float s;                             // Gene de tamanho
    public float timeToDie = 0;                 // Tempo de vida
    public SpriteRenderer sRenderer;            
    Collider2D sCollider;

    // Método para identificar eventos de click do mouse
    void OnMouseDown()
    {
        timeToDie = PopulationManager.elapsed;  // Ciclo de vida do indivíduo
        sRenderer.enabled = false;
        sCollider.enabled = false;
    }

    // Método de inicialização
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        sCollider = GetComponent<Collider2D>();
        sRenderer.color = new Color(r, g, b);               // Adiciona as cores geradas randomicamente ao novo indivíduo da população
        this.transform.localScale = new Vector3(s, s, s);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Rendering.Universal;

public class PopulationManager : MonoBehaviour
{
    public GameObject personPrefab;                             // Prefab do agente
    public int populationSize = 10;                             // Tamanho da população
    List<GameObject> population = new List<GameObject>();       // Lista para armazenamento dos indivíduos
    public static float elapsed = 0;                            // Tempo decorrido
    int trialTime = 10;                                         // Ciclo de vida
    int generation = 1;                                         // Geração inicial

    GUIStyle guiStyle = new GUIStyle();                         // Estilo de GUI (Graphic User Interface)

    // Método para criar o display de informações
    private void OnGUI()
    {
        guiStyle.fontSize = 20;
        guiStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(20, 20, 100, 20), "Geração: " + generation, guiStyle);
        GUI.Label(new Rect(20, 45, 100, 20), "Ciclo de vida: " + (int)elapsed + "s", guiStyle);
    }

    // Método de inicialização
    void Start()
    {
        // Criação da primeira geração, ao iniciar o jogo
        for (int i = 0; i < populationSize; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-9, 9), Random.Range(-4.5f, 4.5f), 0);   // Os valores correspondem às dimensões da área do jogo
            GameObject go = Instantiate(personPrefab, pos, Quaternion.identity);            // Instanciação dos indivíduos
            go.GetComponent<DNA>().r = Random.Range(0.0f, 1.0f);                            // Definição de valor para o gene R
            go.GetComponent<DNA>().g = Random.Range(0.0f, 1.0f);                            // Definição de valor para o gene G
            go.GetComponent<DNA>().b = Random.Range(0.0f, 1.0f);                            // Definição de valor para o gene B
            go.GetComponent<DNA>().s = Random.Range(0.1f, 0.3f);                            // Definição de valor para o gene tamanho
            population.Add(go);                                                             // Adiciona o novo indivíduo gerado a população atual
        }
    }

    // Método para atualização do jogo
    void Update()
    {
        elapsed += Time.deltaTime;          // Tempo decorrido
        if (elapsed > trialTime)             // Condição para mudança de geração
        {
            BreedNewPopulation();           // Método para chamar uma nova geração
            elapsed = 0;                    // Reseta o tempo decorrido
        }
    }

    // Método para criar uma nova população
    void BreedNewPopulation()
    {
        List<GameObject> newPopulation = new List<GameObject>();                                             // Cria uma lista provisória para armazenar os indivíduos da geração atual
        List<GameObject> sortedList = population.OrderBy(o => o.GetComponent<DNA>().timeToDie).ToList();    // Ordena os indivíduos em uma nova lista de acordo com o tempo do seu ciclo de vida

        population.Clear();                                                                                  // Limpa a lista de base da população
        //breed upper half of sorted list
        for (int i = (int)(sortedList.Count / 2.0f) - 1; i < sortedList.Count - 1; i++)
        {
            population.Add(Breed(sortedList[i], sortedList[i + 1]));
            population.Add(Breed(sortedList[i + 1], sortedList[i]));
        }

        // Destrói todos os indivíduos pais e a população provisória
        for (int i = 0; i < sortedList.Count; i++)
        {
            Destroy(sortedList[i]);
        }
        generation++;                       // Atualiza a contagem da geração
    }

    GameObject Breed(GameObject parent1, GameObject parent2)
    {
        Vector3 pos = new Vector3(Random.Range(-9, 9), Random.Range(-4.5f, 4.5f), 0);       // Gera uma posição aleatória no jogo para instanciar o indivíduo filho
        GameObject offspring = Instantiate(personPrefab, pos,Quaternion.identity);          // Cria um indivíduo filho
        DNA dna1 = parent1.GetComponent<DNA>();
        DNA dna2 = parent2.GetComponent<DNA>();
        
        // Core do Algoritmo Genético
        if (Random.Range(0, 1000) > 5)                                                      
        {
            offspring.GetComponent<DNA>().r = Random.Range(0, 10) < 5 ? dna1.r : dna2.r;
            offspring.GetComponent<DNA>().g = Random.Range(0, 10) < 5 ? dna1.g : dna2.g;
            offspring.GetComponent<DNA>().b = Random.Range(0, 10) < 5 ? dna1.b : dna2.b;
            offspring.GetComponent<DNA>().s = Random.Range(0, 10) < 5 ? dna1.s : dna2.s;
        }
        else                                                                                 // Essa estrutura de decisão acrescenta a mutação genética na parte do else
        {
            offspring.GetComponent<DNA>().r = Random.Range(0.0f, 1.0f);
            offspring.GetComponent<DNA>().g = Random.Range(0.0f, 1.0f);
            offspring.GetComponent<DNA>().b = Random.Range(0.0f, 1.0f);
            offspring.GetComponent<DNA>().s = Random.Range(0.1f, 0.3f);
        }
        return offspring;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentSpawner : MonoBehaviour
{
    // Referência com component Prefab
    [SerializeField] GameObject componentPrefab;
    // Quantidade de componentes gerados
    [SerializeField] int numberOfComponents = 10;

    // Limites de geração do componente x e z
    [SerializeField] float xMin = 0f;
    [SerializeField] float xMax = 0f;
    [SerializeField] float zMin = 0f;
    [SerializeField] float zMax = 0f;

    // Valor fixo no eixo y
    [SerializeField] float yFixed = 0f;
    
    void Start()
    {
        for (int i = 0; i < numberOfComponents; i++)
        {
            float x = Random.Range(xMin, xMax);
            float z = Random.Range(zMin, zMax);

            Vector3 position = new Vector3(x, yFixed, z);

            // Instanciando o componente no local determinado
            Instantiate(componentPrefab, position, Quaternion.identity);
        }
    }

}

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyTentaclePrefab;
    public GameObject enemyCloudPrefab;
    public Camera mainCamera;

    private float zone1SpawnInterval = 5f;
    private float zone2SpawnInterval = 4f;
    private float zone3SpawnInterval = 3f;

    private float currentSpawnInterval = 5f;

    private void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        InvokeRepeating("SpawnEnemy", currentSpawnInterval, currentSpawnInterval);
    }

    private void Update()
    {
        // Detectar la zona en la que se encuentra el jugador
        float playerXPosition = transform.position.x;

        if (playerXPosition < 30f && playerXPosition >= 0f)
        {
            UpdateSpawnSpeed(zone1SpawnInterval, 1);
        }
        else if (playerXPosition >= 30f && playerXPosition < 70f)
        {
            UpdateSpawnSpeed(zone2SpawnInterval, 2);
        }
        else if (playerXPosition >= 70f)
        {
            UpdateSpawnSpeed(zone3SpawnInterval, 3);
        }
        else
        {
            // Detener la invocación si el jugador no está en una zona válida
            currentSpawnInterval = Mathf.Infinity;
        }
    }

    private void UpdateSpawnSpeed(float interval, int zone)
    {
        // Establecer una nueva velocidad de spawn si es diferente a la actual
        if (currentSpawnInterval != interval)
        {
            currentSpawnInterval = interval;
            CancelInvoke("SpawnEnemy");
            InvokeRepeating("SpawnEnemy", currentSpawnInterval, currentSpawnInterval);
            Debug.Log("Entrando a zona " + zone + ", la velocidad de spawn ahora será cada " + currentSpawnInterval + " segundos.");
        }
    }

    private void SpawnEnemy()
    {
        // Spawnear enemigos alternados
        if (Random.Range(0, 2) == 0)
        {
            Instantiate(enemyTentaclePrefab, GetRandomSpawnPosition(), Quaternion.identity);
        }
        else
        {
            Instantiate(enemyCloudPrefab, GetRandomSpawnPosition(), Quaternion.identity);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float cameraHeight = mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        float spawnX = mainCamera.transform.position.x + Random.Range(-cameraWidth, cameraWidth);
        float spawnY = mainCamera.transform.position.y + Random.Range(-cameraHeight, cameraHeight);

        return new Vector3(spawnX, spawnY, 0f);
    }
}
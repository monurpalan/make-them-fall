using UnityEngine;

public class Spawner : MonoBehaviour
{
  [SerializeField] private GameObject enemysPrefab;
  [SerializeField] private float duration;
  [SerializeField] private float currentTime;
  [SerializeField] private float[] posX;
  void Start()
  {
    duration = Random.Range(0.5f, 1.5f);
  }
  void Update()
  {
    if (currentTime <= 0)
    {
      currentTime = duration;
      duration = duration - 0.1f;
      if (duration <= 0.2f)
      {
        duration = Random.Range(0.2f, 1.5f);
      }
      Spawn();
    }
    else
    {
      currentTime -= Time.deltaTime;
    }
  }
  private void Spawn()
  {
    GameObject newEnemy = Instantiate(enemysPrefab);
    newEnemy.transform.position = new Vector2(
      posX[Random.Range(0, posX.Length)], transform.position.y
    );
    newEnemy.transform.SetParent(transform);
    if (newEnemy.transform.position.x == posX[1])
    {
      newEnemy.transform.Rotate(0, 180f, 0);
    }
  }
}

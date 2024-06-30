using UnityEngine;

public class Colum_Pool : MonoBehaviour
{
    private GameObject[] colums;
    public int columPoolSize = 5;
    public GameObject columPrefab;
    private Vector2 objectPossition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawaned;
    public float spawnRate = 4f;
    public float columMin = -1f;
    public float columMax = 3.5f;
    private float spawnXPossition = 10f;
    private int curentColum = 0;
    // Start is called before the first frame update
    void Start()
    {
        colums = new GameObject[columPoolSize];
        for (int i = 0; i < columPoolSize; i++)
        {
            colums[i] = (GameObject)Instantiate(columPrefab, objectPossition, Quaternion.identity);
            //instantiating an object casting it to be game object and storing in array
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawaned += Time.deltaTime;

        //Debug.Log("Time is " + timeSinceLastSpawaned);
        if (GameControl.instance.gameOver == false && timeSinceLastSpawaned >= spawnRate)
        {
            //Debug.Log("Condition is true");
            timeSinceLastSpawaned = 0;
            float spawnYPossition = Random.Range(columMin, columMax);
            //Debug.Log(spawnYPossition);
            colums[curentColum].transform.position = new Vector2(spawnXPossition, spawnYPossition);
            curentColum++;
            if (curentColum >= columPoolSize)
            {
                curentColum = 0;
                //Debug.Log("  is ");
            }
        }
    }
}

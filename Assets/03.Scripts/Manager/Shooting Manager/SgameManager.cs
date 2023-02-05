using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class SgameManager : MonoBehaviour
{
    int i; //아이템 배열 변수
    float curItemTime; //아이템 시간~
    float curTime; //현재 시간~

    public GameObject[] enemyObjs;
    public GameObject[] ItemObjs;
    public Transform[] spawnPoints;

    public int kind; //적 종류
    public float maxSpawnDelay;
    public float curSpawnDelay;

    public GameObject player;
    public Image[] lifeImage;
    //public Image[] ItemUIImage;
    public Sprite[] sprites;

    public GameObject gameOverSet;
    public GameObject gameClearSet;
    public PlayableDirector transition;
    public PlayerMovefly Splayer;

    public GameObject tutorial = null;
    public string restartMapName; //이동할 맵 이름
    public string clearMapName; //이동할 맵 이름

    Animator anim;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //ItemUIImage.sprite = sprites[3];
    }

    private void Update()//pc 이동
    {
        curSpawnDelay += Time.deltaTime;
        curItemTime += Time.deltaTime;
        curTime += Time.deltaTime;

        if (curSpawnDelay > maxSpawnDelay)
        {
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 2f);
            curSpawnDelay = 0;
        }
        SpawnItem();
    }

    void SpawnEnemy()
    {
        // 적 종류 범위 설정
        int ranEnemy = Random.Range(0, kind);
        int ranPoint = Random.Range(0, 5);
        GameObject enemy = Instantiate(enemyObjs[ranEnemy],
                                       spawnPoints[ranPoint].position,
                                       spawnPoints[ranPoint].rotation);
        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy eneymyLogic = enemy.GetComponent<Enemy>();
    }

    public void SpawnItem()
    {
        if ((curItemTime >= 10f)&&(i< ItemObjs.Length))
        {
            int ranPoint = Random.Range(0, 5);
            GameObject Item = Instantiate(ItemObjs[i],
                                       spawnPoints[ranPoint].position,
                                       spawnPoints[ranPoint].rotation);
            Rigidbody2D rigid = Item.GetComponent<Rigidbody2D>();
            Item ItemLogic = Item.GetComponent<Item>();

            i++;
            curItemTime = 0;
         
            Debug.Log("시간 초기화");

            if (curTime >= 10 * (kind+1) && (Splayer.item != kind))
                GameOver();
        }
    }

    public void UpdateLifeIcon(int life)
    {
        //#.UI Life Init Disable
        for(int index=0; index < 3; index++)
        {
            lifeImage[index].sprite = sprites[1];
        }
        
        //#.UI Life Active
        for(int index=0; index<life; index++)
        {
            lifeImage[index].sprite = sprites[0];
            //lifeImage[index].color = new Color(1, 1, 1, 1);
        }
    }

    public void GameOver()
    {
        transition.Play();
        Invoke("GameRetry", 0.5f);
    }

    public void GameRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if(tutorial != null)
            SceneManager.LoadScene(restartMapName);
    }
    public void GameClear()
    {
        transition.Play();
        Invoke("NextGame", 1f);
    }
    public void NextButton()
    {
        gameClearSet.SetActive(true);
    }
    public void NextGame()
    {
        Scene scene = SceneManager.GetActiveScene();

        int curScene = scene.buildIndex;
        int nextScene = curScene + 1;
        SceneManager.LoadScene(clearMapName);
    }
}

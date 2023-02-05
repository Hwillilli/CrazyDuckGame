using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class SgameManager : MonoBehaviour
{
    int i; //������ �迭 ����
    float curItemTime; //������ �ð�~
    float curTime; //���� �ð�~

    public GameObject[] enemyObjs;
    public GameObject[] ItemObjs;
    public Transform[] spawnPoints;

    public int kind; //�� ����
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
    public string restartMapName; //�̵��� �� �̸�
    public string clearMapName; //�̵��� �� �̸�

    Animator anim;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //ItemUIImage.sprite = sprites[3];
    }

    private void Update()//pc �̵�
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
        // �� ���� ���� ����
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
         
            Debug.Log("�ð� �ʱ�ȭ");

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

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject circlePrefab;
    public RectTransform gameArea;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI startMessageText;
    public Button nextLevelButton;
    public float gameTime = 30f;
    private float timeRemaining;
    private int score = 0;
    private GameObject currentCircle;
    private Mapa _map;
    private SoundManager _sound;
    private float sizeDecreaseRate = 0.5f;
    private float currentCircleSize = 1f;
    private bool gameRunning = false;
    private bool firstCircleClicked = false;
    private int winScore = 30;

    [SerializeField] public Color[] circleColors;

    void Start()
    {
        StartGame();
        _map = FindObjectOfType<Mapa>();
        _sound = FindObjectOfType<SoundManager>();
        nextLevelButton.gameObject.SetActive(false);
        nextLevelButton.onClick.AddListener(OnNextLevelButtonClicked);
    }

    void Update()
    {
        if (gameRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateUI();
            }
            else
            {
                gameRunning = false;
                timerText.text = "Fim!";
                if (currentCircle != null)
                {
                    Destroy(currentCircle);
                    currentCircle = null;
                }
                CheckWinCondition();
            }

            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (!gameArea.rect.Contains(mousePosition))
                {
                    DeductScore();
                }
            }

            if (currentCircle != null && currentCircleSize > 0)
            {
                if (firstCircleClicked)
                {
                    currentCircleSize -= sizeDecreaseRate * Time.deltaTime;
                    currentCircle.transform.localScale = new Vector3(currentCircleSize, currentCircleSize, 1);
                }

                if (currentCircleSize <= 0)
                {
                    Destroy(currentCircle);
                    currentCircle = null;
                    DeductScore();
                    SpawnCircle();
                }
            }
        }
    }

    void SpawnCircle()
    {
        if (currentCircle != null)
        {
            Destroy(currentCircle);
        }

        Vector3 spawnPosition;

        if (firstCircleClicked)
        {
            float xPos = Random.Range(gameArea.rect.xMin, gameArea.rect.xMax);
            float yPos = Random.Range(gameArea.rect.yMin, gameArea.rect.yMax);
            spawnPosition = new Vector3(xPos, yPos, 0);
            _sound.PopSound();
        }
        else
        {
            spawnPosition = new Vector3(0, 0, 0);
        }

        currentCircle = Instantiate(circlePrefab, spawnPosition, Quaternion.identity);
        currentCircle.transform.SetParent(gameArea, false);

        currentCircleSize = 1f;
        currentCircle.transform.localScale = new Vector3(currentCircleSize, currentCircleSize, 1);

        ChangeCircleColor();

        currentCircle.GetComponent<Button>().onClick.AddListener(OnCircleClicked);
    }

    void ChangeCircleColor()
    {
        if (circleColors.Length > 0)
        {
            Color randomColor = circleColors[Random.Range(0, circleColors.Length)];
            currentCircle.GetComponent<Image>().color = randomColor;
        }
    }

    void OnCircleClicked()
    {
        if (!firstCircleClicked)
        {
            firstCircleClicked = true;
            gameRunning = true;
            startMessageText.gameObject.SetActive(false);
        }
        score++;
        SpawnCircle();
    }

    void DeductScore()
    {
        score = Mathf.Max(0, score - 1);
        UpdateUI();
    }

    void UpdateUI()
    {
        timerText.text = "Tempo: " + Mathf.Ceil(timeRemaining).ToString() + "s";
        scoreText.text = "Pontos: " + score.ToString();

        if (score < winScore){ scoreText.color = circleColors[0]; }
        else{ scoreText.color = circleColors[2]; }
    }


    public void StartGame()
    {
        if (currentCircle != null)
        {
            Destroy(currentCircle);
            currentCircle = null;
        }

        score = 0;
        timeRemaining = gameTime;
        gameRunning = false;
        firstCircleClicked = false;

        startMessageText.gameObject.SetActive(true);

        SpawnCircle();
        UpdateUI();
        timerText.text = "Tempo: " + Mathf.Ceil(timeRemaining).ToString() + "s";
    }

    void CheckWinCondition()
    {
        if (score < winScore)
        {
            _map.HandleEnd("Perdeu...");
        }
        else
        {
            nextLevelButton.gameObject.SetActive(true);
        }
    }

    void OnNextLevelButtonClicked()
    {
        StartGame();
        nextLevelButton.gameObject.SetActive(false);
    }
}

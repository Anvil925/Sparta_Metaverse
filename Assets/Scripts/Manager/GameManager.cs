using UnityEngine;
using UnityEngine.SceneManagement;  // 씬 전환을 위해 필요

public class GameManager : MonoBehaviour
{
    // 게임의 상태 (예: 게임 중, 게임 종료, 일시 정지 등)
    public enum GameState
    {
        Playing,
        GameOver,
        Paused
    }

    public GameState currentGameState;

    public static GameManager Instance;  // 싱글턴 패턴을 위한 Instance

    private void Awake()
    {
        // 싱글턴 패턴: 게임 매니저는 하나만 있어야 한다.
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // 게임 상태를 게임 시작으로 초기화
        currentGameState = GameState.Playing;
    }

    private void Update()
    {
        // 게임 상태에 따라 다르게 처리
        switch (currentGameState)
        {
            case GameState.Playing:
                // 게임 중일 때
                if (Input.GetKeyDown(KeyCode.Escape))  // 예시로 Esc 누르면 일시정지
                {
                    PauseGame();
                }
                break;

            case GameState.GameOver:
                // 게임 오버 처리
                if (Input.GetKeyDown(KeyCode.R))  // R을 눌러서 재시작
                {
                    // RestartGame();
                }
                break;

            case GameState.Paused:
                // 게임이 일시정지 되었을 때
                if (Input.GetKeyDown(KeyCode.Escape))  // Escape 누르면 다시 게임 시작
                {
                    ResumeGame();
                }
                break;
        }
    }

    // 게임 일시 정지
    public void PauseGame()
    {
        currentGameState = GameState.Paused;
        Time.timeScale = 0f;  // 게임 시간 멈추기
        // UI 등을 통해 일시정지 상태를 표시할 수 있음
    }

    // 게임 재개
    public void ResumeGame()
    {
        currentGameState = GameState.Playing;
        Time.timeScale = 1f;  // 게임 시간 재개
    }

    // 게임 오버 처리
    public void GameOver()
    {
        currentGameState = GameState.GameOver;
        Time.timeScale = 0f;  // 게임 시간 멈추기
        // 게임 오버 UI 표시 등을 추가할 수 있음
    }

    // 게임 재시작
    // public void RestartGame()
    // {
    //     Time.timeScale = 1f;  // 게임 시간 재개
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // 현재 씬을 다시 로드
    // }
}
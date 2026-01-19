using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool PlayerDead;
    public GameObject PlayerProj;
    public float PlayerVertSpeed;
    public float PlayerHorizSpeed;
    public float PlayerHorizSpeedMax;
    public float PlayerVertSpeedMax;
    public float PlayerJumpPower;
    public float PlayerMaxFall;
    public bool TurnedAround;
    public int CurrentMoney;
    private float PlayerAttackCooldown;
    private float PlayerJumpCooldown;
    public String MoneyTag;
    public String WinPortal;
    public TextMeshProUGUI TotalMoney;
    public int DeathLayer;
    public String WinCollider;
    public TextMeshProUGUI PointCounter;
    public GameObject YouAreDeadMenu;

    public void Update()
    {
        if (!PlayerDead)
        {
            var attackAction = GetComponent<PlayerInput>().actions.FindAction("Attack", false);
            PlayerAttackCooldown -= Time.deltaTime;
            if (attackAction != null && attackAction.enabled && attackAction.ReadValue<float>() > 0f && PlayerAttackCooldown <= 0)
            {
                PlayerAttackCooldown = 0.05f;
                PlayerHorizSpeed = 0.8f * PlayerHorizSpeedMax;
            }
            var jumpAction = GetComponent<PlayerInput>().actions.FindAction("Jump", false);
            PlayerJumpCooldown -= Time.deltaTime;
            if (jumpAction != null && jumpAction.enabled && jumpAction.ReadValue<float>() > 0f && PlayerJumpCooldown <= 0)
            {
                PlayerJumpCooldown = 0.1f;
                PlayerVertSpeed = PlayerJumpPower;
                this.GetComponent<Animator>().Play("Flap");
            }
            PlayerHorizSpeed = Mathf.Lerp(PlayerHorizSpeed, PlayerHorizSpeedMax, Time.deltaTime);
            PlayerVertSpeed = Mathf.Clamp(PlayerVertSpeed - Time.deltaTime, PlayerMaxFall, PlayerJumpPower);
            foreach (var col in Physics2D.OverlapBoxAll(transform.position, GetComponent<Collider2D>().bounds.size, 0))
            {
                if (col.gameObject.tag == MoneyTag)
                {
                    CurrentMoney += col.GetComponent<MoneyAmount>().amount;
                }
                if (col.gameObject.tag == WinPortal)
                {
                    ResetGame(true);
                }
                if (col.gameObject.layer == 1 << DeathLayer)
                {
                    PlayerDead = true;
                }
            }
            YouAreDeadMenu.SetActive(false);
        } 
        PointCounter.text = CurrentMoney.ToString();
        TotalMoney.text = m.n.Money.ToString();
        this.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(PlayerHorizSpeedMax, PlayerVertSpeed);

        if (PlayerDead)
        {
            PlayerHorizSpeed = 0;
            PlayerVertSpeed = 0;
            YouAreDeadMenu.SetActive(true);
        }
    }

    public void ResetGame(bool Won)
    {
        if (Won) m.n.Money += CurrentMoney;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void RestartFromLoss()
    {
        ResetGame(false);
    }

}

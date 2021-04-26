using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject gameManager;
    public Image healthUI;
    public Sprite[] healthSprites;
    private static Vector3 pos;
    public static int health;
    public float moveSpeed = 5;
    public static bool damaged = false;
    float damagedCooldown = 1f;
    float lifeRegen = 2f;
    float dirX;
    float dirY;
    // Start is called before the first frame update
    void Start(){
        pos = transform.position;
        health = 100;
        rb = GetComponent<Rigidbody2D>();
        damaged = false;
    }

    void Update(){
        //se sofreu dano, vai realizar algumas verificações
        if(health < 100){
            //se tiver a menos de 50 (metade) da vida, muda o sprite para indicar
            ChangeSprite();
            //morte, chamada da tela de game over e parando os objetos
            if(health <= 0){
                Destroy(gameObject);
                gameManager.GetComponent<GameManager>().GameOver();
                return;
            }
            //se não sofrer dano por algum tempo, recupera a vida para o máximo;
            Regen();
        }

        //verificação de toque para movimentação
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            transform.position = touchPosition;
        }
    }

    void ChangeSprite(){
        if(health <= 50 && health > 25){
            healthUI.sprite = healthSprites[1];
        }
        //see tivere a menos de 25 (1/4) da vida, muda o sprite para indicar
        if(health <= 25){
            healthUI.sprite = healthSprites[2];
        }
    }

    void Regen(){
        //tempo de espera para recuperar vida atingido
        if(lifeRegen <= 0){
            health = 100;
            lifeRegen = 3;
            healthUI.sprite = healthSprites[0];
        }
        //contagem regressiva para a recuperação de vida
        else{
            lifeRegen -= Time.deltaTime;
        }

        //se foi atingido novamente, reseta o tempo de espera para recperação de vida
        if(damaged){
            lifeRegen = 3;
            //contagem regressiva para perder o efeito de danificado
            damagedCooldown -= Time.deltaTime;
            if(damagedCooldown <= 0) damaged = false;
        }
    }

    public static Vector3 GetPlayerPosition(){
        Debug.Log("Chamou");
        return pos;
    }
}

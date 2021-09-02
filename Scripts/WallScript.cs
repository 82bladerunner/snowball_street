using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int WallHP = 100;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private HealthBar healthBar;
    public int BonusHP = 25;

    public Sprite[] wallSprite;

    #region colors
    Color orangeCustom = new Color(0.6226f,0.5918f, 0.1732f);
    Color greenCustom = new Color(0.4307f, 0.6226f, 0.1732f);
    Color redCustom = new Color(0.6226f, 0.1732f, 0.1732f);
    Color whiteCustom = new Color(0.9528302f, 0.9483357f, 0.9483357f);
    Color lerpedColor;
    #endregion

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   


        lerpedColor = Color.Lerp(whiteCustom, redCustom, Mathf.PingPong(Time.time, 0.3f));

        if(WallHP > 75)
        {
            healthBar.SetColor(greenCustom);
        }
        if(WallHP >= 50f && WallHP < 75f)
        {
            spriteRenderer.sprite = wallSprite[1];
        }
        else if(WallHP >= 25f && WallHP < 50f)
        {   
            spriteRenderer.sprite = wallSprite[2];
            healthBar.SetColor(orangeCustom);
        }
        else if(WallHP > 0f && WallHP < 25f)
        {
            spriteRenderer.sprite = wallSprite[3];
            healthBar.SetColor(lerpedColor);
        }
        else if(WallHP <= 0f)
        {
            WallHP = 0;
            Destroy(gameObject);
        }
            //Health bar scaling depending on how much hp left
            float HealthLeft = WallHP*0.01f;
            healthBar.SetSize(HealthLeft);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("EnemyProjectile"))
        {
            WallHP--;
        }
    }

    public void IncreaseHP()
    {
        if(WallHP< 100-BonusHP)
        {
            WallHP += BonusHP;
        }
        else if(WallHP > 100-BonusHP)
        {
            WallHP += (100-WallHP);
        }
    }

    public void DozerDamage()
    {
        WallHP -= 10;
    }
    
}

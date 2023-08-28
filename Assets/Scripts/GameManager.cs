using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Image FadeImage;
    private int score;
    private Blade _blade;
    private Spawner _spawner;


    private void Awake()
    {
        _blade = FindObjectOfType<Blade>();
        _spawner = FindObjectOfType<Spawner>();
    }

    private void Start()
    {
        newgame();
    }

    void newgame()
    {  
        Time.timeScale = 1f;
        _blade.enabled = true;
        _spawner.enabled = true;
        score = 0;
        scoreText.text = "Score: "+score.ToString();
        clearscene();
    }

    void clearscene()
    {
        Fruitt[] fruitts = FindObjectsOfType<Fruitt>();
        foreach (Fruitt fruitt in fruitts)
        {
            Destroy(fruitt.gameObject);  
        }
        Bomb[] bombs = FindObjectsOfType<Bomb>();
        foreach (Bomb bomb in bombs)
        {
            Destroy(bomb.gameObject);  
        }
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: "+score.ToString();
    }

    public void explode()
    {
        _blade.enabled = false;
        _spawner.enabled = false;
        StartCoroutine(ExplodeSeq());
    }


    IEnumerator ExplodeSeq()
    {
        float elapsed = 0f;
        float duration = .5f;
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);//verilen bir sayıyı 0 ile 1 arasında sınırlar. Eğer verilen sayı 0'dan küçükse, 0 olarak döndürülür; eğer 1'den büyükse, 1 olarak döndürülür; eğer sayı 0 ile 1 arasındaysa, kendisi olarak döndürülür.
            FadeImage.color = Color.Lerp(Color.clear, Color.white, t);
            Time.timeScale = 1f - t;
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        yield return new WaitForSecondsRealtime(1.3f);

        newgame();
        elapsed = 0f;
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            FadeImage.color = Color.Lerp(Color.white, Color.clear, t);
           
            elapsed += Time.unscaledDeltaTime;//scale zaten değişmiş oldugu için unscale yapıyoruz.
            yield return null;
        }
      
        
    }
}

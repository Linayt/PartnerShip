using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShipLife : MonoBehaviour
{
    [SerializeField] float startLife;
    [SerializeField] float maxLife;

    [SerializeField] string sceneToLoadonDeath;

    float life;


    SpaceShipControler sControler;
    public void Initialize()
    {
        sControler = GetComponent<SpaceShipControler>();
        life = startLife;
    }

    public void TakeDamage(float damage)
    {
        life += damage;
        if (life <= 0) Death();
    }

    public void Death()
    {
        if (sceneToLoadonDeath != "") SceneManager.LoadScene(sceneToLoadonDeath);
    }
}

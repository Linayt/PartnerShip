using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShipLife : MonoBehaviour
{
    [SerializeField] float startLife;
    [SerializeField] float maxLife;

    [SerializeField] string sceneToLoadonDeath;

    [SerializeField] MeshRenderer lifeBarMeshRenderer;

    float life;

    Material matLifeBar;

    SpaceShipControler sControler;
    public void Initialize()
    {
        sControler = GetComponent<SpaceShipControler>();
        life = startLife;
        matLifeBar = lifeBarMeshRenderer.material;
        SetLifeBarValue();
    }

    public void TakeDamage(float damage)
    {
        life += damage;
        SetLifeBarValue();
        if (life <= 0) Death();
    }

    public void Death()
    {
        if (sceneToLoadonDeath != "") SceneManager.LoadScene(sceneToLoadonDeath);
    }


    public void SetLifeBarValue()
    {
        matLifeBar.SetFloat("_HP", life / maxLife);
    }
}

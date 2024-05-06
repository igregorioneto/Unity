using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOpcoes : MonoBehaviour
{
    // Variáveis
    public Toggle tgSom;
    public Text txtQualidade;

    // Métodos
    public void MudarQualidade(bool diminuindo)
    {
        if (diminuindo)
            QualitySettings.DecreaseLevel();
        else
            QualitySettings.IncreaseLevel();

        PlayerPrefs.SetInt("qualidade", QualitySettings.GetQualityLevel());

        AtualizarTelaOpcoes();
        SoundManager.SomBotao();
    }
    public void ToggleSom()
    {
        if (tgSom.isOn)
            PlayerPrefs.SetInt("som", 0);
        else
            PlayerPrefs.SetInt("som", 1);

        AtualizarTelaOpcoes();
        SoundManager.SomBotao();
    }
    private void AtualizarTelaOpcoes()
    {
        if(PlayerPrefs.HasKey("som"))
        {
            if (PlayerPrefs.GetInt("som") == 1)
            { 
                tgSom.isOn = false;
                AudioListener.volume = 0f;
            }
            else
            { 
                tgSom.isOn = true;
                AudioListener.volume = 1f;
            }
        }
        else
        {
            tgSom.isOn = true;
            AudioListener.volume = 1f;
        }
        
        txtQualidade.text = QualitySettings.names[QualitySettings.GetQualityLevel()];
    }

    // Métodos Internos da Unity
    private void Start()
    {
        if (PlayerPrefs.HasKey("qualidade"))
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("qualidade"));

        AtualizarTelaOpcoes();
    }
    private void OnEnable()
    {
        AtualizarTelaOpcoes();
    }
}

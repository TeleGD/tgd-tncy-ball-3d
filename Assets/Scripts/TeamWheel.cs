
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * Cette classe gère la vue de la gestion de clubs dans le menu.
 * C'est la classe TeamSelector qui gère le modèle.
 */

public class TeamWheel : MonoBehaviour
{
    public RawImage[] teamLogosUI;
    public MeshRenderer[] playerLogos;
    public Text[] teamNames;

    // Start is called before the first frame update
    void Start()
    {
        UpdateLogos();
    }

    private void UpdateLogos()
    {
        teamLogosUI[0].texture = TeamSelector.GetSelection(0).GetLogo();
        teamLogosUI[1].texture = TeamSelector.GetSelection(1).GetLogo();
        playerLogos[0].material.mainTexture = TeamSelector.GetSelection(0).GetLogo();
        playerLogos[1].material.mainTexture = TeamSelector.GetSelection(1).GetLogo();
        teamNames[0].text = TeamSelector.GetSelection(0).GetName();
        teamNames[1].text = TeamSelector.GetSelection(1).GetName();
    }

    public void PreviousTeam(int playerID)
    {
        TeamSelector.selectedTeam[playerID]--;
        if (TeamSelector.selectedTeam[playerID] < 0)
            TeamSelector.selectedTeam[playerID] = TeamSelector.teams.Count - 1;
        UpdateLogos();
    }

    public void NextTeam(int playerID)
    {
        TeamSelector.selectedTeam[playerID]++;
        if (TeamSelector.selectedTeam[playerID] >= TeamSelector.teams.Count)
            TeamSelector.selectedTeam[playerID] = 0;
        UpdateLogos();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            PreviousTeam(0);
        if (Input.GetKeyDown(KeyCode.D))
            NextTeam(0);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            PreviousTeam(1);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            NextTeam(1);
        if (Input.GetKeyDown(KeyCode.Space))
            StartGame();
        /*
        else if (Input.GetKeyDown(d) || (Input.GetMouseButtonUp(0) && coll.name == "Right" && gameObject.name == coll.gameObject.transform.parent.parent.name))
        {
            
            if (SceneManager.GetActiveScene().name == "TeamSelector")
            {

                // Check mouse controls
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    coll = hit.collider;
                }

                    if (timer >= 0.1)
                {
                    gameObject.transform.GetChild(1).Find(selected).GetComponent<MeshRenderer>().material = mat1;
                    timer = 0;
                }
                else if (timer > 0)
                {
                    timer = timer + Time.deltaTime;
                }
                else if (Input.GetKeyDown(q) || (Input.GetMouseButtonUp(0) && coll.name == "Left" && gameObject.name == coll.gameObject.transform.parent.parent.name))
                {
                    i -= 1;
                    if (i < 0) i = teams.Count - 1;
                    this.gameObject.transform.Find("Team_Logo").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", Resources.Load<Texture>(string.Concat("Logos/", teams[i].getFileId())));
                    this.gameObject.transform.GetChild(1).Find("Name").GetComponent<TextMesh>().text = teams[i].getName();
                    updateLogos();
                    gameObject.transform.GetChild(1).Find("Left").GetComponent<MeshRenderer>().material = mat2;
                    selected = "Left";
                    timer = timer + Time.deltaTime;
                }
                else if (Input.GetKeyDown(d) || (Input.GetMouseButtonUp(0) && coll.name == "Right" && gameObject.name == coll.gameObject.transform.parent.parent.name))
                {
                    i += 1;
                    if (i >= teams.Count) i = 0;
                    this.gameObject.transform.Find("Team_Logo").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", Resources.Load<Texture>(string.Concat("Logos/", teams[i].getFileId())));
                    this.gameObject.transform.GetChild(1).Find("Name").GetComponent<TextMesh>().text = teams[i].getName();
                    updateLogos();
                    gameObject.transform.GetChild(1).Find("Right").GetComponent<MeshRenderer>().material = mat2;
                    selected = "Right";
                    timer = timer + Time.deltaTime;
                }

            }
            */
    }

    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenElementController : MonoBehaviour
{
    private Vector2 screenBounds;
    [SerializeField] GameObject[] skull_prefab_list;
    [SerializeField] GameObject red_Wizard_Prefab;
    [SerializeField] Canvas windowIn;
    // Start is called before the first frame update
    void Start()
    {
        var redWizard = Instantiate(red_Wizard_Prefab, new Vector3((4)*-0.96f, 7.36f, 0f), Quaternion.identity);
        redWizard.transform.SetParent(windowIn.transform, false);
        redWizard.transform.localPosition = redWizard.transform.localPosition;
        redWizard.transform.localScale = new Vector2(3f,3f);
        
        var skull01 = Instantiate(skull_prefab_list[0], new Vector3((0)*-0.96f, 7.36f, 0), Quaternion.identity);
        skull01.transform.SetParent(windowIn.transform, false);
        skull01.transform.localPosition = skull01.transform.localPosition;
        skull01.transform.localScale = new Vector2(3f,3f);

        var skull02 = Instantiate(skull_prefab_list[1], new Vector3((1)*-0.96f, 7.36f, 0), Quaternion.identity);
        skull02.transform.SetParent(windowIn.transform, false);
        skull02.transform.localPosition = skull02.transform.localPosition;
        skull02.transform.localScale = new Vector2(3f,3f);
        
        var skull03 = Instantiate(skull_prefab_list[2], new Vector3((2)*-0.96f, 7.36f, 0), Quaternion.identity);
        skull03.transform.SetParent(windowIn.transform, false);
        skull03.transform.localPosition = skull03.transform.localPosition;
        skull03.transform.localScale = new Vector2(3f,3f);
        
        var skull04 = Instantiate(skull_prefab_list[3], new Vector3((3)*-0.96f, 7.36f, 0), Quaternion.identity);
        skull04.transform.SetParent(windowIn.transform, false);
        skull04.transform.localPosition = skull04.transform.localPosition;
        skull04.transform.localScale = new Vector2(3f,3f);
    }

    // Update is called once per frame
    void Update()
    {
    }
}

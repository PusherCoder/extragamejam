#pragma warning disable 0649

using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private TextMeshProUGUI patientInfoText;
    [SerializeField] private TextMeshProUGUI potionResultText;
    
    private Patient activePatient;
    public Patient ActivePatient 
    {
        get
        {
            return activePatient;
        }

        private set
        {
            activePatient = value;
            patientInfoText.text = GetPatientInfoText(value);
        }
    }

    public PotionRecipe ActivePotion;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GeneratePatient();
        RefreshPotion();
    }

    private void GeneratePatient()
    {
        Patient patient = new Patient
        {
            Heart = OrganState.ExcessAir,
            Intestines = OrganState.ExcessWater,
            Mind = OrganState.ExcessFire,
            Lungs = OrganState.ExcessAir
        };

        ActivePatient = patient;
    }

    private string GetPatientInfoText(Patient patient)
    {
        string infoString = "Patient Info\n\nSymptoms:";

        //Heart
        if (patient.Heart == OrganState.ExcessAir)
            infoString += "\n-Heart palpitation";

        //Intestines
        if (patient.Intestines == OrganState.ExcessWater)
            infoString += "\n-Diarrhea";

        //Mind
        if (patient.Mind == OrganState.ExcessFire)
            infoString += "\n-Mania";

        //Lungs
        if (patient.Lungs == OrganState.ExcessAir)
            infoString += "\n-Dry cough";
        else if (patient.Lungs == OrganState.ExcessEarth)
            infoString += "\n-Shortness of breath";

        //Skin
        if (patient.Skin == OrganState.ExcessFire)
            infoString += "\n-Rash";

        return infoString;
    }

    private void RefreshPotion()
    {
        ActivePotion = new PotionRecipe();
    }

    public void BrewPotion()
    {
        //Initial patient state
        int heartFireWater = 0;
        if (ActivePatient.Heart == OrganState.ExcessFire) heartFireWater++;
        if (ActivePatient.Heart == OrganState.ExcessWater) heartFireWater--;
        int heartEarthAir = 0;
        if (ActivePatient.Heart == OrganState.ExcessEarth) heartEarthAir++;
        if (ActivePatient.Heart == OrganState.ExcessAir) heartEarthAir--;

        int intestinesFireWater = 0;
        if (ActivePatient.Intestines == OrganState.ExcessFire) intestinesFireWater++;
        if (ActivePatient.Intestines == OrganState.ExcessWater) intestinesFireWater--;
        int intestinesEarthAir = 0;
        if (ActivePatient.Intestines == OrganState.ExcessEarth) intestinesEarthAir++;
        if (ActivePatient.Intestines == OrganState.ExcessAir) intestinesEarthAir--;

        int mindFireWater = 0;
        if (ActivePatient.Mind == OrganState.ExcessFire) mindFireWater++;
        if (ActivePatient.Mind == OrganState.ExcessWater) mindFireWater--;
        int mindEarthAir = 0;
        if (ActivePatient.Mind == OrganState.ExcessEarth) mindEarthAir++;
        if (ActivePatient.Mind == OrganState.ExcessAir) mindEarthAir--;

        int lungsFireWater = 0;
        if (ActivePatient.Lungs == OrganState.ExcessFire) lungsFireWater++;
        if (ActivePatient.Lungs == OrganState.ExcessWater) lungsFireWater--;
        int lungsEarthAir = 0;
        if (ActivePatient.Lungs == OrganState.ExcessEarth) lungsEarthAir++;
        if (ActivePatient.Lungs == OrganState.ExcessAir) lungsEarthAir--;

        int skinFireWater = 0;
        if (ActivePatient.Skin == OrganState.ExcessFire) skinFireWater++;
        if (ActivePatient.Skin == OrganState.ExcessWater) skinFireWater--;
        int skinEarthAir = 0;
        if (ActivePatient.Skin == OrganState.ExcessEarth) skinEarthAir++;
        if (ActivePatient.Skin == OrganState.ExcessAir) skinEarthAir--;

        //Change state with potion 
        lungsEarthAir -= ActivePotion.KingsRoot;
        heartEarthAir -= ActivePotion.KingsRoot;

        skinFireWater -= ActivePotion.SootheWeed;
        intestinesFireWater -= ActivePotion.SootheWeed;

        heartEarthAir += ActivePotion.ArrowRoot;
        intestinesFireWater += ActivePotion.ArrowRoot;

        mindFireWater -= ActivePotion.KoboldsTooth;
        lungsEarthAir += ActivePotion.KoboldsTooth;

        if (heartFireWater == 0 && heartEarthAir == 0 &&
            intestinesFireWater == 0 && intestinesEarthAir == 0 &&
            mindFireWater == 0 && mindEarthAir == 0 &&
            lungsFireWater == 0 && lungsEarthAir == 0 &&
            skinFireWater == 0 && skinEarthAir == 0)
        {
            potionResultText.text = "Success";
        }
        else
        {
            potionResultText.text = "Failure";
        }
    }
}

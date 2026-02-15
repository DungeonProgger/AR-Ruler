using UnityEngine;

public class addNotes : MonoBehaviour
{
    public GameObject Note;
    public GameObject SpawnNote;
    public int NotesCount;
    [SerializeField] private Transform root;
    public string NoteText = " ";
    private int count = 1;
    private float coeff = 0f;
    public void addNote()
    {
        if (NoteText != " ")
        {
            if (NotesCount == 4)
            {
                coeff = 0f;
                NotesCount = 0;
                for (int i = 0; i < root.transform.childCount; i++)
                {
                    GameObject child = root.GetChild(i).gameObject;
                    Destroy(child);
                }
            }
            GameObject Note1 = Instantiate(Note, root);

            NotesCount++;
            Note1.transform.localPosition = new Vector3(0, -coeff, 0);
            Note1.gameObject.GetComponent<Note>().HeaderNote.text = "Измерение " + count + " " +
                "";
            Note1.gameObject.GetComponent<Note>().textNote.text = NoteText;
            count++;
            coeff += 0.15f;          
        }
    }
   
}

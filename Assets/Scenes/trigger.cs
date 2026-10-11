using UnityEngine;

public class trigger : MonoBehaviour
{
    public GameObject cetakanLedakan;
    public GameObject toppipe;
    public GameObject bottompipe;
    public float kecepatanBuka = 2f;
    private bool mesinMenyala = false;
    public float jarakBukaAtas = 5f;
    public float jarakBukaBawah = 5f;
    private float jarakTempuhAtas = 0f;
    private float jarakTempuhBawah = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mesinMenyala == true)
        {
            // toppipe.transform.Translate(Vector3.up * kecepatanBuka * Time.deltaTime);
            // bottompipe.transform.Translate(Vector3.down * kecepatanBuka * Time.deltaTime);\
            if (jarakTempuhAtas < jarakBukaAtas)
            {
            toppipe.transform.Translate(Vector3.up * kecepatanBuka * Time.deltaTime);
            jarakTempuhAtas += kecepatanBuka * Time.deltaTime;
            }
            if (jarakTempuhBawah < jarakBukaBawah)
            {
                bottompipe.transform.Translate(Vector3.down * kecepatanBuka * Time.deltaTime);
                jarakTempuhBawah += kecepatanBuka * Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D yangMenyentuh)
    {
        Debug.Log("Tombol disentuh oleh: "  + yangMenyentuh.gameObject.name + " dengan Tag: " + yangMenyentuh.gameObject.tag);
        if (yangMenyentuh.gameObject.CompareTag("peluru"))
        {
            Debug.Log("Mesin pintu berhasil dinyalakan");
            mesinMenyala = true;
            GameObject ledakanBaru = Instantiate(cetakanLedakan, yangMenyentuh.transform.position, Quaternion.identity);
            Destroy(ledakanBaru, 0.4f);
            Destroy(yangMenyentuh.gameObject);
            GetComponent<Collider2D>().enabled = false;
        }
    }
}

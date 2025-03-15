using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLock2 : MonoBehaviour
{
    public TextMeshProUGUI textScorePlayer; // Hiển thị số quái vật đã giết
    public TextMeshProUGUI textScoreUnlock; // Hiển thị số quái vật cần giết để mở khóa
    private int scoreUnlock = 50; // Số quái vật cần giết để mở khóa
    public GameObject canvasScoreUnlock; // Canvas hiển thị thông báo
    public GameObject costumeObject; // Đối tượng sẽ được mở khóa
    public Image imagebg;
    public Image imageEnemy;
    public Sprite spriteEnemy;
    public string monsterType; // Loại quái vật cần giết để unlock

    private bool isUnlocked = false; // Trạng thái mở khóa

    private void Start()
    {
        // Kiểm tra điều kiện mở khóa ngay khi bắt đầu
        CheckAndUnlock();
    }

    private void Update()
    {
        // Liên tục kiểm tra điều kiện mở khóa nếu chưa mở
        if (!isUnlocked)
        {
            CheckAndUnlock();
        }
    }

    // Phương thức được gọi khi click vào ButtonLock
    private void OnMouseDown()
    {
        // Chỉ kiểm tra thủ công nếu chưa mở khóa
        if (!isUnlocked)
        {
            ClickOutsideHandler.isClickOnButtonLock = true;
            ShowUnlockCondition();
        }
    }

    private void CheckAndUnlock()
    {
        int killedEnemies = KilledEnemiesManager.GetKilledEnemies(monsterType); // Lấy số quái vật đã giết

        // Kiểm tra nếu số quái vật đã giết >= số quái vật cần giết
        if (killedEnemies >= scoreUnlock)
        {
            UnlockCostume(); // Mở khóa
            isUnlocked = true; // Đánh dấu đã mở khóa
        }
    }

    private void ShowUnlockCondition()
    {
        // Hiển thị thông báo điều kiện mở khóa
        canvasScoreUnlock.SetActive(true);
        imagebg.enabled = false;
        imageEnemy.sprite = spriteEnemy;
        imageEnemy.gameObject.transform.localScale = new Vector3(1, 1, 1);

        int killedEnemies = KilledEnemiesManager.GetKilledEnemies(monsterType); // Lấy số quái vật đã giết
        textScorePlayer.text = killedEnemies.ToString(); // Hiển thị số quái vật đã giết
        textScoreUnlock.text = scoreUnlock.ToString(); // Hiển thị số quái vật cần giết
    }

    private void UnlockCostume()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(false); // Ẩn lock
        }

        if (costumeObject != null)
        {
            costumeObject.SetActive(true); // Hiển thị đối tượng được mở khóa
        }

        // Ẩn canvas thông báo (nếu đang hiển thị)
        canvasScoreUnlock.SetActive(false);
    }
}
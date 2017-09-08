using UnityEngine;

public interface ItemInPlay {

    /* 파라미터 slotAmount의 정수값 만큼 [슬롯 오브젝트] 생성 */
    void InitSlot(int slotAmount);

    /* 데이터베이스의 id번째 아이템을 [슬롯]에 생성한다.
     * 1. Title
     * 2. Price
     * 3. Item Image*/
    void AddItem(int id);

    /* 구매하고자 하는 아이템 클릭시 발생하는 이벤트
     * 1. Turret
     * 2. Weapon
     * 3. Core*/
    void PuchaseItem(GameObject item);

}

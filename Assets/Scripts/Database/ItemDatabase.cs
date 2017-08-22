public interface ItemDatabase {

    /* 해당파일(.json)에서 JsonData 형식의 데이터를 가져온다. */
    void JsonMapping();

    /* List<TurretDTO>에 아이템에 대한 데이터Set들을 담는다. */
    void ConstructItemDatabase();
}

namespace Characters {
    public class CharacterController : CharacterBase
    {
        // Start is called before the first frame update
        void Start()
        {
            this.setCharacterToTile(GridController.getElementById("5-4"));
        }
    }
}

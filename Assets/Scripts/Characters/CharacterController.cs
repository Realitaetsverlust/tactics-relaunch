namespace Characters {
    public class CharacterController : CharacterBase
    {
        // Start is called before the first frame update
        void Start()
        {
            this.setCharacterToTile(GridController.getElementById("7-8"));
        }
    }
}

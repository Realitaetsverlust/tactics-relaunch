using Elements;

namespace Characters {
    public class CharacterController : CharacterBase
    {
        public void init() {
            this.charName = "Luyen";
            this.level = 50;
            this.exp = 0;
            this.maxHp = 850;
            this.currentHp = 650;
            this.maxMp = 210;
            this.currentMp = 210;
        }
        
        void Start()
        {
            this.setCharacterToTile(GridController.getElementById("7-8"));
        }
    }
}

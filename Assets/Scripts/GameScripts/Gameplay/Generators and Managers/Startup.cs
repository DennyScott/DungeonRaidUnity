
public class Startup : AdvMonoBehaviour {
    private Managers _managersRunner;
    private Generators _generatorsRunner;

	// Use this for initialization
	void Awake () {
	    CollectManagerAndGenerator();
	    CollectChildren();
	    InitializeChildren();
	}

    void CollectManagerAndGenerator() {
        _managersRunner = GetComponentInChildren<Managers>();
        _generatorsRunner = GetComponentInChildren<Generators>();
    }

    void CollectChildren() {
        _generatorsRunner.CollectGenerators();
        _managersRunner.CollectManagers();
    }

    void InitializeChildren() {
        _generatorsRunner.InitalizeGenerators();
        _managersRunner.InitializeManagers();
    }

}

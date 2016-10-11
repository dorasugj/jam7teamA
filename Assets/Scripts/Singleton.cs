
public class Singleton  {

    public float MixMiso;

    public float UpMiso;

    public float MisoPeturn;

    public int misocount;

    static Singleton instance;

    private Singleton()
    {

    }

    public static Singleton Instance
    {
        get{
            if (instance == null)
                instance = new Singleton();
            return instance;
        }
        
    } 

    
}

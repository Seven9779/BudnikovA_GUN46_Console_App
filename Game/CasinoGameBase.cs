namespace CasinoGame;

public abstract class CasinoGameBase
{
    public CasinoGameBase()
    {
        
    }
    
    protected abstract void FactoryMethod();
    
    public abstract void PlayGame();
    
    public event Action OnWin;
    public event Action OnLoose;
    public event Action OnDraw;

    protected void OnWinInvoke()
    {
        OnWin?.Invoke();
    }

    protected void OnLooseInvoke()
    {
        OnLoose?.Invoke();
    }
    
    protected void OnDrawInvoke()
    {
        OnDraw?.Invoke();
    }
}
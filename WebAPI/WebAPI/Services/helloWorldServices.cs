class helloWorldServices: IhelloWorldServices
{
    public string GetHello(){
        return "Hello";
    }
}

public interface IhelloWorldServices{
    string GetHello();
}
public class Result<T>
{
    public int code{get;set;} = 200;
    public bool success{get;set;} = true;
    public T data{get;set;}
    public string message{get;set;} = "";
}
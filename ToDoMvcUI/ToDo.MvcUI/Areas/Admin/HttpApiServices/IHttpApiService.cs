namespace ToDo.MvcUI.Areas.Admin.HttpApiServices
{
    public interface IHttpApiService
    {
        //Get
        //Post
        //Put
        //Delete

        //api'a get request atılmasını sağlaycak ve oradan dönen response'u geri döndürecek
        Task<T> GetData<T>(string endPoint,string token = null);

        //api'a post request atılmasını sağlaycak ve oradan dönen response'u geri döndürecek
        Task<T> PostData<T>(string endPoint,string jsonData, string token = null);
        Task<T> PutData<T>(string endPoint,string jsonData, string token = null);

        Task<T> DeleteData<T>(string endPoint, string token = null);



    }
}

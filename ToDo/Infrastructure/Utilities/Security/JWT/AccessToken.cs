namespace Infrastructure.Utilities.Security.JWT
{
    //Bu sınıfın nesnesini oluşturup tokenı talep eden client göndereceğiz
    public class AccessToken
    {
        public List<string> Claims { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}

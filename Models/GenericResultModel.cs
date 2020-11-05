using Models.AuthenticationModels;

namespace Models
{
    public class GenericResultModel<TData>
    {
        public bool Success { get; set; }
        public TData Data { get; set; }
        public ErrorModel Error { get; set; }
    }
}
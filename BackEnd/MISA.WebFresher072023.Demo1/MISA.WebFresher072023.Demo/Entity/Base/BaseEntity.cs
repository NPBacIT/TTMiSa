namespace MISA.WebFresher072023.Demo
{
    public abstract class BaseEntity
    {
        public string? CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public string? ModifileBy
        {
            get; set;

        }
        public DateTime? ModifiedDate { get; set; }
    }
}

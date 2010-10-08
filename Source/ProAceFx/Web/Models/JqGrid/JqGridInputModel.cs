namespace ProAceFx.Web.Models.JqGrid
{
    public abstract class JqGridInputModel
    {
        public int page { get; set; }
        public int rows { get; set; }
        public string sidx { get; set; }
        public string sord { get; set; }
        public string searchterm { get; set; }
    }
}
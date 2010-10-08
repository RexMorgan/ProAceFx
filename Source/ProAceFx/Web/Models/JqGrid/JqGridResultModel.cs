namespace ProAceFx.Web.Models.JqGrid
{
    public class JqGridResultModel
    {
        public int total { get; set; }
        public int page { get; set; }
        public int records { get; set; }
        public JqGridRow[] rows { get; set; }
    }
}
using WMS.Models;

namespace WMS.ViewModels
{
    public class ItemGroupViewModels
    {
        public List<ItemGroup>? ParentGroup { get; set; }
 
        public int GroupId { get; set; }
        public string ? GroupName { get; set; }
        public string ?Description { get; set; }
        public int? Ranking { get; set; }
        public bool Status { get; set; }
        public int? ParentGroupId  { get; set; }
  
    }
}

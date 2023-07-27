using simple_record.core.enums;

namespace simple_record.service.InputModels
{
    public class GetAllPeoplesInputModel 
    {
        public string? SearchTerm { get; set; }
        public PersonTypes? Type { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}

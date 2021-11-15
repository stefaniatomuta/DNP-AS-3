using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models {
public class Interest {
    [MaxLength(128)]
    public string Type { get; set; }
    
    [MaxLength(256)]
    public string Description { get; set; }

    public List<Child> Children { get; set; }
}
}
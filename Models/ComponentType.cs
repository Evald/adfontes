using System.Collections.Generic;

namespace Adfontes.Models
{
    public class ComponentType
    {
        public int ComponentTypeId { get; set; }
        public string Title { get; set; }
        public List<Component> Components { get; set; }
    }
}

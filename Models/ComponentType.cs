using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Adfontes.Models
{
     [DataContract]
    public class ComponentType
    {
        [DataMember]
        public int ComponentTypeId { get; set; }
        [DataMember]
        public string Title { get; set; }
        public List<Component> Components { get; set; }
    }
}

using RG.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.AttributesDTO
{
    public class ItemAttribute
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string DefaultValue { get; set; }
        public string ValueDescription { get; set; }
        public int? Priority { get; set; }
        public string Type { get; set; }
        public string ColorName { get; set; }
        [JsonConverter(typeof(JsonBooleanConverter))]
        public bool? IsHighLevel { get; set; }
        public int AttributeType { get; set; }
        public string HTMLCode { get; set; }
        public string text { get; set; }
    }

    public class Attributes
    {
        public Attributes()
        {
            Attribute = new List<ItemAttribute>();
        }
        public int MRPItemCode { get; set; }
        public string MRPItemName { get; set; }
        public long AttributeInstanceID { get; set; }
        public List<ItemAttribute> Attribute { get; set; }
        public ItemAttribute GetMRPItemAttributeInfo(int AttributeId)
        {
            try
            {
                var list = this.Attribute;
                return Attribute.Where(b => b.ID == AttributeId)
                        .Select(s => new ItemAttribute
                        {
                            AttributeType = s.AttributeType,
                            ColorName = s.ColorName,
                            DefaultValue = s.DefaultValue,
                            HTMLCode = s.HTMLCode,
                            ID = s.ID,
                            IsHighLevel = s.IsHighLevel,
                            Name = s.Name,
                            Priority = s.Priority,
                            text = s.text,
                            Type = s.Type,
                            ValueDescription = s.ValueDescription
                        }).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

    }
}

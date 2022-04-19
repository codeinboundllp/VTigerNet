using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace Jayrock.Json.Conversion
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class JsonExcludeExportAttribute : Attribute, IPropertyDescriptorCustomization, IObjectMemberExporter
    {
        public void Apply(PropertyDescriptor property)
        {
            var services = (IServiceContainer)property;
            services.AddService(typeof(IObjectMemberExporter), this);
        }

        void IObjectMemberExporter.Export(ExportContext context, JsonWriter writer, object source)
        {
            //writer.WriteMember(_property.Name);
            //context.Export(_property.GetValue(source), writer);
        }
    }
}

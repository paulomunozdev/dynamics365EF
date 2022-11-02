using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D365.DOMAIN.Enum
{
    public enum ProductListState
    {
        [Description("Entered")]
        Ingresado = 1,
        [Description("In Validation")]
        EnProceso = 2,
        [Description("Processed")]
        EnAnalisis = 3,
        [Description("Shipped")]
        Completado = 4,
        [Description("Delivered")]
        ProblemaData = 5,
        [Description("Error In Validation")]
        ProblemaLogica = 6,
    }
}

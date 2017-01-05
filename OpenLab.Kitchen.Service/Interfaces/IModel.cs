using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.Kitchen.Service.Interfaces
{
    public interface IStreamingModel
    {
        string RoutingKey();
    }

    public interface IDataModel
    {
        string IdString();
    }
}

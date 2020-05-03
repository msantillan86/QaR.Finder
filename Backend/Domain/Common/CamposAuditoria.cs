using System;

namespace QaR.Finder.Domain.Common
{
    public abstract class CamposAuditoria
    {
        public string CreadoPor { get; set; }

        public DateTime CreadoFecha { get; set; }

        public string ActualizadoPor { get; set; }

        public DateTime? ActualizadoFecha { get; set; }
    }
}

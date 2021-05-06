using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTransferenciaBancaria.Enum
{
    public enum TipoConta
    {
        [Description("Pessoa Fisíca")]
        PessoaFisica = 1,
        [Description("Pessoa Jurídica")]
        PessoaJuridica = 2
    }
}

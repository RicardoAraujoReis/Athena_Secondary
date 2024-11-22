using Athena.Models;
using common.Requests;
using Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.CommandsHandler.Validators;

public class ClienteValidator
{
    public ClienteValidator(Cliente clienteRequest)
    {
        
    }

    /*public bool CreateClienteValidator(Cliente clienteRequest)
    {
        if(Convert.ToChar(clienteRequest.Cli_ativo.ToUpper()) == 'N')
        {
            return false;
        }
        return true;
    }*/
}

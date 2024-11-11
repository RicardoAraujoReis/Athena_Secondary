using Application.Features.Commands;
using Athena.Models;
using Common.Wrapper;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.CommandsHandler;

public class CreateUsuLhnCommandsHandler : IRequestHandler<CreateUsuLhnCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public CreateUsuLhnCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(CreateUsuLhnCommand request, CancellationToken cancellationToken)
    {
        var UsuLhn = request.CreateUsuLhn.Adapt<UsuLhn>();
        await _unitOfWork.WriteDataFor<UsuLhn>().AddAsync(UsuLhn);
        await _unitOfWork.CommitAsync(cancellationToken);

        return new ResponseWrapper<int>().Success(UsuLhn.Id, "Registro criado com sucesso.");
    }
}

public class UpdateUsuLhnCommandsHandler : IRequestHandler<UpdateUsuLhnCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public UpdateUsuLhnCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(UpdateUsuLhnCommand request, CancellationToken cancellationToken)
    {
        var UsuLhnToFind = await _unitOfWork.ReadDataFor<UsuLhn>().GetByIdAsync(request.UpdateUsuLhn.Id);

        if (UsuLhnToFind is not null)
        {
            var updateUsuLhn = new UsuLhn
            {
                Id = request.UpdateUsuLhn.Id,
                Uln_usu_identi = request.UpdateUsuLhn.Uln_usu_identi,
                Uln_lhn_identi = request.UpdateUsuLhn.Uln_lhn_identi,
                Uln_usubdd = request.UpdateUsuLhn.Uln_usubdd,
                Uln_usucri = request.UpdateUsuLhn.Uln_usucri,
                Uln_usualt = request.UpdateUsuLhn.Uln_usualt,
                Uln_datcri = request.UpdateUsuLhn.Uln_datcri,
                Uln_datalt = request.UpdateUsuLhn.Uln_datalt
            };

            await _unitOfWork.WriteDataFor<UsuLhn>().UpdateAsync(updateUsuLhn);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(updateUsuLhn.Id, "Atualização realizada com sucesso");
        }

        return new ResponseWrapper<int>().Failed("Falha ao atualizar o registro");
    }
}

public class DeleteUsuLhnCommandsHandler : IRequestHandler<DeleteUsuLhnCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public DeleteUsuLhnCommandsHandler(IUnitOfWork<int> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseWrapper<int>> Handle(DeleteUsuLhnCommand request, CancellationToken cancellationToken)
    {
        var UsuLhnToFind = await _unitOfWork.ReadDataFor<UsuLhn>().GetByIdAsync(request.IdUsuLhnToDelete);

        if (UsuLhnToFind is not null)
        {
            await _unitOfWork.WriteDataFor<UsuLhn>().DeleteAsync(UsuLhnToFind);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(UsuLhnToFind.Id, "Deleção realizada com sucesso");
        }
        return new ResponseWrapper<int>().Failed("Falha na deleção do registro");
    }
}

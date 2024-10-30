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

        return new ResponseWrapper<int>().Success(UsuLhn.Uln_identi, "Registro criado com sucesso.");
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
        var UsuLhnToFind = await _unitOfWork.ReadDataFor<UsuLhn>().GetByIdAsync(request.UpdateUsuLhn.Uln_identi);

        if (UsuLhnToFind is not null)
        {
            var updateUsuLhn = UsuLhnToFind.UpdateUsuLhn(
                request.UpdateUsuLhn.Uln_identi,
                request.UpdateUsuLhn.Uln_usu_identi,
                request.UpdateUsuLhn.Uln_lhn_identi,
                request.UpdateUsuLhn.Uln_usubdd,
                request.UpdateUsuLhn.Uln_usucri,
                request.UpdateUsuLhn.Uln_usualt,
                request.UpdateUsuLhn.Uln_datcri,
                request.UpdateUsuLhn.Uln_datalt
            );

            await _unitOfWork.WriteDataFor<UsuLhn>().UpdateAsync(updateUsuLhn);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(updateUsuLhn.Uln_identi, "Atualização realizada com sucesso");
        }

        return new ResponseWrapper<int>().Failed("Falha ao atualizar o registro");
    }
}

public class DeleteUsuLhnCommandsHandler : IRequestHandler<DeleteUsuLhnCommand, ResponseWrapper<int>>
{
    private readonly IUnitOfWork<int> _unitOfWork;

    public async Task<ResponseWrapper<int>> Handle(DeleteUsuLhnCommand request, CancellationToken cancellationToken)
    {
        var UsuLhnToFind = await _unitOfWork.ReadDataFor<UsuLhn>().GetByIdAsync(request.IdUsuLhnToDelete);

        if (UsuLhnToFind is not null)
        {
            await _unitOfWork.WriteDataFor<UsuLhn>().DeleteAsync(UsuLhnToFind);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(UsuLhnToFind.Uln_identi, "Deleção realizada com sucesso");
        }
        return new ResponseWrapper<int>().Failed("Falha na deleção do registro");
    }
}

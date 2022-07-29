using AutoMapper;
using Calabonga.AspNetCore.Controllers;
using Calabonga.AspNetCore.Controllers.Base;
using Calabonga.UnitOfWork;
using PowerfulSpace.Facts.Web.Data;
using PowerfulSpace.Facts.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PowerfulSpace.Facts.Web.Controllers.Administrator.Queries
{

    public class NotificationGetByIdRequst : RequestBase<NotificationViewModel>
    {
        public Guid Id { get; }

        public NotificationGetByIdRequst(Guid id) => Id = id;
    }




    public class NotificationGetByIdRequestHandler : RequestHandlerBase<NotificationGetByIdRequst, NotificationViewModel?>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public NotificationGetByIdRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public override async Task<NotificationViewModel?> Handle(NotificationGetByIdRequst request, CancellationToken cancellationToken)
        {
            var notification = await _unitOfWork
                .GetRepository<Notification>()
                .GetFirstOrDefaultAsync(
                selector: NotificationSelectors.Default,
                predicate: x => x.Id == request.Id);



            return notification;
        }
    }
}

﻿using Fabrica.Models;
using MediatR;

namespace Fabrica.Persistence.Mediator.Requests;

public record QueryEntityRequest<TCriteria, TEntity>(TCriteria Criteria) : BaseQueryEntityRequest<TCriteria,TEntity>(Criteria) where TCriteria : BaseCriteria where TEntity : class;

public record QueryEntityRequest<TEntity>( string Rql ) : BaseQueryEntityRequest<TEntity>( Rql ) where TEntity : class;